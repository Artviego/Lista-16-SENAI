using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;

namespace Lista_16
{
    public class Funcionario
    {
        private int id;
        private string nome;
        private string cpf;
        private DateTime dataNasc;
        private string cargo;
        private string setor;
        private decimal salario;
        private string sexo;

        public int Id
        {
            get { return id; }
            set { value = id; }
        }

        public string Nome
        {
            get { return nome; }
            set { nome = value; }
        }

        public string CPF
        {
            get { return cpf; }
            set { cpf = value; }
        }

        public DateTime DataNascimento
        {
            get { return dataNasc; }
            set { dataNasc = value; }
        }

        public string Cargo
        {
            get { return cargo; }
            set { cargo = value; }
        }

        public string Setor
        {
            get { return setor; }
            set { setor = value; }
        }

        public decimal Salario
        {
            get { return salario; }
            set { salario = value; }
        }

        public string Sexo
        {
            get { return sexo; }
            set { sexo = value; }
        }

        // Insere um funcionário
        public bool InserirFuncionario()
        {
            try
            {
                using (MySqlConnection conexaoBanco = new ConexaoDB().Conectar())
                {
                    string inserir = "INSERT INTO Funcionario (ID, Nome, CPF, DataNascimento, Cargo, Setor, Salario, Sexo) values (@id, @nome, @cpf, @datanascimento, @cargo, @setor, @salario, @sexo);";

                    MySqlCommand comando = new MySqlCommand(inserir, conexaoBanco);
                    comando.Parameters.AddWithValue("@id", Id);
                    comando.Parameters.AddWithValue("@nome", Nome);
                    comando.Parameters.AddWithValue("@cpf", CPF);
                    comando.Parameters.AddWithValue("@datanascimento", DataNascimento);
                    comando.Parameters.AddWithValue("@cargo", Cargo);
                    comando.Parameters.AddWithValue("@setor", Setor);
                    comando.Parameters.AddWithValue("@salario", Salario);
                    comando.Parameters.AddWithValue("@sexo", Sexo);

                    int resultado = comando.ExecuteNonQuery();

                    if (resultado > 0)
                    {
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro ao cadastrar o funcionário - Método -> " + ex.Message, "Erro - Cadastrar Funcionario DB", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }

        // Atualiza o funcionário
        public bool AtualizarFuncionario()
        {
            try
            {
                using (MySqlConnection conexaoBanco = new ConexaoDB().Conectar())
                {
                    string atualizaSetor = "UPDATE funcionarios SET Nome = @Nome, CPF = @CPF, DataNascimento = @DataNascimento, " +
                           "Cargo = @Cargo, Setor = @Setor, Salario = @Salario, Sexo = @Sexo WHERE ID = @ID";

                    MySqlCommand cmd = new MySqlCommand(atualizaSetor, conexaoBanco);
                    cmd.Parameters.AddWithValue("@ID", Id);
                    cmd.Parameters.AddWithValue("@Nome", Nome);
                    cmd.Parameters.AddWithValue("@CPF", CPF);
                    cmd.Parameters.AddWithValue("@DataNascimento", DataNascimento);
                    cmd.Parameters.AddWithValue("@Cargo", Cargo);
                    cmd.Parameters.AddWithValue("@Setor", Setor);
                    cmd.Parameters.AddWithValue("@Salario", Salario);
                    cmd.Parameters.AddWithValue("@Sexo", Sexo);

                    conexaoBanco.Open();

                    int resultado = cmd.ExecuteNonQuery();

                    if (resultado > 0)
                    {
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Não foi possível atualizar o funcionário -> " + ex.Message, "Erro - Atualizar Funcionario", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }

        // Exclui um funcionário
        public bool ExcluirFuncionario()
        {
            try
            {
                using (MySqlConnection conexaoBanco = new ConexaoDB().Conectar())
                {
                    string excluirSetor = "DELETE FROM funcionario WHERE id = @id";

                    MySqlCommand comando = new MySqlCommand(excluirSetor, conexaoBanco);

                    comando.Parameters.AddWithValue("@id", Id);

                    int resultado = comando.ExecuteNonQuery();

                    if (resultado > 0)
                    {
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Não foi possível excluir o setor -> " + ex.Message, "Erro - Excluir Setor", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }

        // Lista todos os funcionários
        public static List<Funcionario> ListarTodosFuncionarios()
        {
            List<Funcionario> funcionarios = new List<Funcionario>();

            using (MySqlConnection conexaoBanco = new ConexaoDB().Conectar())
            {
                string listarFuncionarios = "SELECT * FROM funcionario";

                MySqlCommand comando = new MySqlCommand(listarFuncionarios, conexaoBanco);

                MySqlDataReader reader = comando.ExecuteReader();
                while (reader.Read())
                {
                    funcionarios.Add(new Funcionario
                    {
                        Id = reader.GetInt32("ID"),
                        Nome = reader.GetString("Nome"),
                        CPF = reader.GetString("CPF"),
                        DataNascimento = reader.GetDateTime("DataNascimento"),
                        Cargo = reader.GetString("Cargo"),
                        Setor = reader.GetString("Setor"),
                        Salario = reader.GetDecimal("Salario"),
                        Sexo = reader.GetString("Sexo")
                    });
                }
            }
            return funcionarios;
        }

        // Lista os funcionários por nome
        public static List<Funcionario> ListarFuncionarioPorNome(string nome)
        {
            List<Funcionario> funcionarios = new List<Funcionario>();

            using (MySqlConnection conexaoBanco = new ConexaoDB().Conectar())
            {
                string listarPorNome = "SELECT * FROM funcionario WHERE nome LIKE @nome";

                MySqlCommand comando = new MySqlCommand(listarPorNome, conexaoBanco);
                comando.Parameters.AddWithValue("@nome", "%" + nome + "%");

                MySqlDataReader reader = comando.ExecuteReader();
                while (reader.Read())
                {
                    funcionarios.Add(new Funcionario
                    {
                        Id = reader.GetInt32("ID"),
                        Nome = reader.GetString("Nome"),
                        CPF = reader.GetString("CPF"),
                        DataNascimento = reader.GetDateTime("DataNascimento"),
                        Cargo = reader.GetString("Cargo"),
                        Setor = reader.GetString("Setor"),
                        Salario = reader.GetDecimal("Salario"),
                        Sexo = reader.GetString("Sexo")
                    });
                }
            }

            return funcionarios;
        }
    }
}
