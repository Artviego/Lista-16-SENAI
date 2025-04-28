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
            maskedTextBox1.PromptChar = ' '; // Utiliza espa�o como caractere de preenchimento
            maskedTextBox1.Enabled = true;   // Garante que o controle esteja habilitado
        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {

        }

        private void btnGravar_Click(object sender, EventArgs e)
        {
            try
            {
                // Coleta os dados dos campos do formul�rio
                string nome = txtNome.Text;
                string cpf = maskedTextBox1.Text;
                DateTime dataNascimento = dateTimePicker1.Value;
                string cargo = txtCargo.Text;
                string setor = comboSetor.SelectedItem?.ToString(); // Assume que o ComboBox Setor foi preenchido com dados
                decimal salario = Convert.ToDecimal(txtSalario.Text);
                string sexo = rbMasculino.Checked ? "M" : "F"; // Assume que tem radio buttons para M/F

                // Valida��o dos dados
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

                    // Insere o funcion�rio no banco de dados
                    funcionario.InserirFuncionario();

                    MessageBox.Show("Funcion�rio cadastrado com sucesso!", "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    // Atualiza o DataGridView com os dados mais recentes
                    ListarFuncionarios();

                    // Limpa os campos ap�s o cadastro
                    LimparCampos();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("N�o foi poss�vel realizar o cadastro: " + ex.Message, "Erro - Cadastro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // C�DIGOS PARA A VALIDA��O DE DADOS

        // Validar CPF
        public bool ValidarCPF(string cpf)
        {
            // Remove qualquer m�scara (como . ou -)
            cpf = cpf.Replace(".", "").Replace("-", "");

            // Verifica se o CPF tem 11 d�gitos
            if (cpf.Length != 11 || !Regex.IsMatch(cpf, @"\d{11}"))
            {
                return false;
            }

            // Verifica se todos os d�gitos s�o iguais (exemplo: 111.111.111-11)
            if (new string(cpf[0], 11) == cpf)
            {
                return false;
            }

            // Valida o primeiro d�gito verificador
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

            // Valida o segundo d�gito verificador
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

        // Valida os campos obrigat�rios
        public bool ValidarCamposObrigatorios(string nome, string cpf, string cargo, string setor, decimal salario, string sexo)
        {
            if (string.IsNullOrWhiteSpace(nome))
            {
                MessageBox.Show("O campo Nome � obrigat�rio.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            if (string.IsNullOrWhiteSpace(cpf) || !ValidarCPF(cpf))
            {
                MessageBox.Show("O CPF informado � inv�lido.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            if (string.IsNullOrWhiteSpace(cargo))
            {
                MessageBox.Show("O campo Cargo � obrigat�rio.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            if (string.IsNullOrWhiteSpace(setor))
            {
                MessageBox.Show("O campo Setor � obrigat�rio.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            if (salario <= 0)
            {
                MessageBox.Show("O campo Sal�rio deve ser maior que 0.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            if (string.IsNullOrWhiteSpace(sexo))
            {
                MessageBox.Show("O campo Sexo � obrigat�rio.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            return true;
        }

        // Data de nascimento
        public bool ValidarDataNascimento(DateTime dataNascimento)
        {
            // Verifica se a data de nascimento � v�lida e se o funcion�rio tem pelo menos 18 anos
            DateTime dataAtual = DateTime.Now;
            int idade = dataAtual.Year - dataNascimento.Year;

            if (dataNascimento.Date > dataAtual.AddYears(-idade)) idade--;

            if (idade < 18)
            {
                MessageBox.Show("O funcion�rio deve ter pelo menos 18 anos.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            return true;
        }

        // Sal�rio
        public bool ValidarSalario(decimal salario)
        {
            if (salario <= 0)
            {
                MessageBox.Show("O sal�rio deve ser maior que zero.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            return true;
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            // Coleta os dados dos campos do formul�rio
            int id = Convert.ToInt32(txtID.Text);  // ID do funcion�rio selecionado
            string nome = txtNome.Text;
            string cpf = maskedTextBox1.Text;
            DateTime dataNascimento = dateTimePicker1.Value;
            string cargo = txtCargo.Text;
            string setor = comboSetor.SelectedItem?.ToString();  // Setor selecionado
            decimal salario = Convert.ToDecimal(txtSalario.Text);
            string sexo = rbMasculino.Checked ? "M" : "F";  // Sexo selecionado

            // Valida��o dos dados
            if (ValidarCamposObrigatorios(nome, cpf, cargo, setor, salario, sexo) && ValidarDataNascimento(dataNascimento))
            {
                // Cria o objeto Funcionario com as novas informa��es
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

                // Atualiza os dados do funcion�rio no banco de dados
                funcionario.AtualizarFuncionario();

                MessageBox.Show("Funcion�rio atualizado com sucesso!", "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information);

                // Atualiza o DataGridView com os dados mais recentes
                ListarFuncionarios();

                // Limpa os campos ap�s a edi��o
                LimparCampos();
            }
        }

        private void btnExcluir_Click(object sender, EventArgs e)
        {
            // Verifica se algum funcion�rio foi selecionado para excluir
            if (string.IsNullOrEmpty(txtID.Text))
            {
                MessageBox.Show("Por favor, selecione um funcion�rio para excluir.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            int id = Convert.ToInt32(txtID.Text);

            // Confirma��o de exclus�o
            DialogResult result = MessageBox.Show("Tem certeza de que deseja excluir este funcion�rio?", "Confirmar Exclus�o", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (result == DialogResult.Yes)
            {
                // Cria o objeto Funcionario
                Funcionario funcionario = new Funcionario { Id = id };

                // Exclui o funcion�rio do banco de dados
                funcionario.ExcluirFuncionario();

                MessageBox.Show("Funcion�rio exclu�do com sucesso!", "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information);

                // Atualiza o DataGridView com os dados mais recentes
                ListarFuncionarios();

                // Limpa os campos ap�s a exclus�o
                LimparCampos();
            }
        }

        private void ListarFuncionarios()
        {
            Funcionario funcionario = new Funcionario();
            List<Funcionario> lista = Funcionario.ListarTodosFuncionarios();  // M�todo para listar todos os funcion�rios do banco

            // Preenche o DataGridView com a lista de funcion�rios
            dataGridView1.DataSource = lista;
        }

        private void LimparCampos()
        {
            txtID.Clear();
            txtNome.Clear();
            maskedTextBox1.Clear();
            dateTimePicker1.Value = DateTime.Now;
            txtCargo.Clear();
            comboSetor.SelectedIndex = -1; // Limpa a sele��o do ComboBox
            txtSalario.Clear();
            rbMasculino.Checked = false;
            rbFeminino.Checked = false;
        }
    }
}
