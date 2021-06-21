using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace Modelo
{
    public partial class Form1 : Form
    {
        LinkedList<String> lista = new LinkedList<String>();

        public Form1()
        {
            InitializeComponent();
            carregar();
        }

        private void BtnFechar_Click(object sender, EventArgs e)
        {
            
            this.Close();
        }

        private void BtnSobre_Click(object sender, EventArgs e)
        {

        }

        void salvar()
        {
            using (BinaryWriter writer = new BinaryWriter(File.Open("deque.txt", FileMode.Create)))
            {
                writer.Write(lista.Count());
                foreach (String nome in lista)
                {
                    writer.Write(nome);
                }
            }   
        }

        void carregar()
        {
            if (File.Exists("deque.txt"))
            {
                using (BinaryReader reader = new BinaryReader(File.Open("deque.txt", FileMode.Open)))
                {
                    int qtd = reader.ReadInt32();
                    for (int i = 0; i < qtd; i++)
                    {
                        String nome;
                        nome = reader.ReadString();
                        lista.AddLast(nome);
                    }// fim for
                }

            }// Fila normal


            mostra();
        }

        void mostra()
        {
            listPessoas.Items.Clear();
            foreach(String nome in lista)
            {
                listPessoas.Items.Add(nome);
            }

        }
        //---------------
        void limpa()
        {
            txtNome.Clear();
            txtAdd.Clear();
            txtNome.Focus();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            String nome;

            nome = txtNome.Text;
            lista.AddFirst(nome);
            limpa();
            mostra();
        }

        private void btnRemove_Click(object sender, EventArgs e)
        {
            if (lista.Count > 0)
            {
                String nome;
                nome = lista.First(); // pegando o elemento sem remover
                lista.RemoveFirst(); // remove sem retornar
                lblProx.Text = nome;
                mostra();
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            salvar();
        }



        private void btnRemoveLast_Click(object sender, EventArgs e)
        {
            if (lista.Count > 0)
            {
                String nome;
                nome = lista.Last(); // pegando o elemento sem remover
                lista.RemoveLast(); // remove sem retornar
                lblProx.Text = nome;
                mostra();
            }
        }

        private void btnAddLast_Click(object sender, EventArgs e)
        {
            String nome;
            nome = txtNome.Text;
            lista.AddLast(nome);
            limpa();
            mostra();
        }

        private void btnFrist_Click(object sender, EventArgs e)
        {
            if (lista.Count > 0)
            {
                String nome;
                nome = lista.First(); // pegando o elemento sem remover
                MessageBox.Show("Primeiro elemeto da fila: " + nome);
            }
            else
            {
                MessageBox.Show("Fila vazia :(");
            }
        }

        private void btnLast_Click(object sender, EventArgs e)
        {
            if (lista.Count > 0)
            {
                String nome;
                nome = lista.Last(); // pegando o elemento sem remover
                MessageBox.Show("Último elemeto da fila: " + nome);
            }
            else
            {
                MessageBox.Show("Fila vazia :(");
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            LinkedListNode<String> apos = lista.FindLast(txtAdd.Text);
            String nome;
            nome = txtNome.Text;
            lista.AddAfter(apos, nome);
            limpa();
            mostra();
        }

        private void btnBefore_Click(object sender, EventArgs e)
        {
            LinkedListNode<String> antes = lista.FindLast(txtAdd.Text);
            String nome;
            nome = txtNome.Text;
            lista.AddBefore(antes, nome);
            limpa();
            mostra();
        }
    }
}
