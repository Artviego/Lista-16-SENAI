using System.Text.RegularExpressions;

namespace Lista_16
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            ListarFuncionarios();
            maskedTextBox1.Mask = "000.000.000-00";
            maskedTextBox1.PromptChar = ' '; // Utiliza espaço como caractere de preenchimento
            maskedTextBox1.Enabled = true;   // Garante que o controle esteja habilitado
        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {

        }

        private void btnGravar_Click(object sender, EventArgs e)
        {
            try
            {
                // Coleta os dados dos campos do formulário
                string nome = txtNome.Text;
                string cpf = maskedTextBox1.Text;
                DateTime dataNascimento = dateTimePicker1.Value;
                string cargo = txtCargo.Text;
                string setor = comboSetor.SelectedItem?.ToString(); // Assume que o ComboBox Setor foi preenchido com dados
                decimal salario = Convert.ToDecimal(txtSalario.Text);
                string sexo = rbMasculino.Checked ? "M" : "F"; // Assume que tem radio buttons para M/F

                // Validação dos dados
                if (ValidarCamposObrigatorios(nome, cpf, cargo, setor, salario, sexo) && ValidarDataNascimento(dataNascimento))
                {
                    // Cria o objeto Funcionario
                    Funcionario funcionario = new Funcionario
                    {
                        Nome = nome,
                        CPF = cpf,
                        DataNascimento = dataNascimento,
                        Cargo = cargo,
                        Setor = setor,
                        Salario = salario,
                        Sexo = sexo
                    };

                    // Insere o funcionário no banco de dados
                    funcionario.InserirFuncionario();

                    MessageBox.Show("Funcionário cadastrado com sucesso!", "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    // Atualiza o DataGridView com os dados mais recentes
                    ListarFuncionarios();

                    // Limpa os campos após o cadastro
                    LimparCampos();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Não foi possível realizar o cadastro: " + ex.Message, "Erro - Cadastro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // CÓDIGOS PARA A VALIDAÇÃO DE DADOS

        // Validar CPF
        public bool ValidarCPF(string cpf)
        {
            // Remove qualquer máscara (como . ou -)
            cpf = cpf.Replace(".", "").Replace("-", "");

            // Verifica se o CPF tem 11 dígitos
            if (cpf.Length != 11 || !Regex.IsMatch(cpf, @"\d{11}"))
            {
                return false;
            }

            // Verifica se todos os dígitos são iguais (exemplo: 111.111.111-11)
            if (new string(cpf[0], 11) == cpf)
            {
                return false;
            }

            // Valida o primeiro dígito verificador
            int soma = 0;
            for (int i = 0; i < 9; i++)
            {
                soma += (int)Char.GetNumericValue(cpf[i]) * (10 - i);
            }
            int resto = soma % 11;
            int digito1 = (resto < 2) ? 0 : 11 - resto;
            if (digito1 != (int)Char.GetNumericValue(cpf[9]))
            {
                return false;
            }

            // Valida o segundo dígito verificador
            soma = 0;
            for (int i = 0; i < 10; i++)
            {
                soma += (int)Char.GetNumericValue(cpf[i]) * (11 - i);
            }
            resto = soma % 11;
            int digito2 = (resto < 2) ? 0 : 11 - resto;
            if (digito2 != (int)Char.GetNumericValue(cpf[10]))
            {
                return false;
            }

            return true;
        }

        // Valida os campos obrigatórios
        public bool ValidarCamposObrigatorios(string nome, string cpf, string cargo, string setor, decimal salario, string sexo)
        {
            if (string.IsNullOrWhiteSpace(nome))
            {
                MessageBox.Show("O campo Nome é obrigatório.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            if (string.IsNullOrWhiteSpace(cpf) || !ValidarCPF(cpf))
            {
                MessageBox.Show("O CPF informado é inválido.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            if (string.IsNullOrWhiteSpace(cargo))
            {
                MessageBox.Show("O campo Cargo é obrigatório.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            if (string.IsNullOrWhiteSpace(setor))
            {
                MessageBox.Show("O campo Setor é obrigatório.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            if (salario <= 0)
            {
                MessageBox.Show("O campo Salário deve ser maior que 0.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            if (string.IsNullOrWhiteSpace(sexo))
            {
                MessageBox.Show("O campo Sexo é obrigatório.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            return true;
        }

        // Data de nascimento
        public bool ValidarDataNascimento(DateTime dataNascimento)
        {
            // Verifica se a data de nascimento é válida e se o funcionário tem pelo menos 18 anos
            DateTime dataAtual = DateTime.Now;
            int idade = dataAtual.Year - dataNascimento.Year;

            if (dataNascimento.Date > dataAtual.AddYears(-idade)) idade--;

            if (idade < 18)
            {
                MessageBox.Show("O funcionário deve ter pelo menos 18 anos.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            return true;
        }

        // Salário
        public bool ValidarSalario(decimal salario)
        {
            if (salario <= 0)
            {
                MessageBox.Show("O salário deve ser maior que zero.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            return true;
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            // Coleta os dados dos campos do formulário
            int id = Convert.ToInt32(txtID.Text);  // ID do funcionário selecionado
            string nome = txtNome.Text;
            string cpf = maskedTextBox1.Text;
            DateTime dataNascimento = dateTimePicker1.Value;
            string cargo = txtCargo.Text;
            string setor = comboSetor.SelectedItem?.ToString();  // Setor selecionado
            decimal salario = Convert.ToDecimal(txtSalario.Text);
            string sexo = rbMasculino.Checked ? "M" : "F";  // Sexo selecionado

            // Validação dos dados
            if (ValidarCamposObrigatorios(nome, cpf, cargo, setor, salario, sexo) && ValidarDataNascimento(dataNascimento))
            {
                // Cria o objeto Funcionario com as novas informações
                Funcionario funcionario = new Funcionario
                {
                    Id = id,
                    Nome = nome,
                    CPF = cpf,
                    DataNascimento = dataNascimento,
                    Cargo = cargo,
                    Setor = setor,
                    Salario = salario,
                    Sexo = sexo
                };

                // Atualiza os dados do funcionário no banco de dados
                funcionario.AtualizarFuncionario();

                MessageBox.Show("Funcionário atualizado com sucesso!", "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information);

                // Atualiza o DataGridView com os dados mais recentes
                ListarFuncionarios();

                // Limpa os campos após a edição
                LimparCampos();
            }
        }

        private void btnExcluir_Click(object sender, EventArgs e)
        {
            // Verifica se algum funcionário foi selecionado para excluir
            if (string.IsNullOrEmpty(txtID.Text))
            {
                MessageBox.Show("Por favor, selecione um funcionário para excluir.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            int id = Convert.ToInt32(txtID.Text);

            // Confirmação de exclusão
            DialogResult result = MessageBox.Show("Tem certeza de que deseja excluir este funcionário?", "Confirmar Exclusão", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (result == DialogResult.Yes)
            {
                // Cria o objeto Funcionario
                Funcionario funcionario = new Funcionario { Id = id };

                // Exclui o funcionário do banco de dados
                funcionario.ExcluirFuncionario();

                MessageBox.Show("Funcionário excluído com sucesso!", "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information);

                // Atualiza o DataGridView com os dados mais recentes
                ListarFuncionarios();

                // Limpa os campos após a exclusão
                LimparCampos();
            }
        }

        private void ListarFuncionarios()
        {
            Funcionario funcionario = new Funcionario();
            List<Funcionario> lista = Funcionario.ListarTodosFuncionarios();  // Método para listar todos os funcionários do banco

            // Preenche o DataGridView com a lista de funcionários
            dataGridView1.DataSource = lista;
        }

        private void LimparCampos()
        {
            txtID.Clear();
            txtNome.Clear();
            maskedTextBox1.Clear();
            dateTimePicker1.Value = DateTime.Now;
            txtCargo.Clear();
            comboSetor.SelectedIndex = -1; // Limpa a seleção do ComboBox
            txtSalario.Clear();
            rbMasculino.Checked = false;
            rbFeminino.Checked = false;
        }
    }
}
