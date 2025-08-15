using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ListaDeCompraFoda
{
    public partial class ListaDeCompras : Form
    {
        public ListaDeCompras()
        {
            InitializeComponent();
        }

        private void btnAdicionar_Click(object sender, EventArgs e)
        {
            if (txbProduto.Text.Length == 0)
            {
                MessageBox.Show("O nome do produto não pode estar vazio!",
                    "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                // Mudar a cor do fundo e a cor da letra
                txbProduto.BackColor = Color.Red;
                txbProduto.ForeColor = Color.White;
            }
            else if (txbProduto.Text.Length < 2)
            {
                MessageBox.Show("O nome do produto precisa ter no minimo 2(Duas) letras!",
                    "Erro!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                // Mudar a cor do fundo e a cor da letra
                txbProduto.BackColor = Color.Red;
                txbProduto.ForeColor = Color.White;
            }
            else
            {
                // Verificar se o item esta na lista:
                if (libCompras.Items.Contains(txbProduto.Text))
                {
                    MessageBox.Show($"Ja existe {txbProduto.Text} na lista!",
                        "Erro!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {

                    //Adicionar o item na lista
                    libCompras.Items.Add(txbProduto.Text);
                    MessageBox.Show($"{txbProduto.Text} foi adicionado na lista de compras!",
                        "show!", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    // Retornar o txbproduto a cor normal
                    txbProduto.BackColor = Color.White;
                    txbProduto.ForeColor = Color.Black;

                    //Limpar o campo
                    txbProduto.Clear();
                }
            }

        }

        private void btnLimpar_Click(object sender, EventArgs e)
        {
            DialogResult resposta = MessageBox.Show("Tem certeza que deseja apagar tudo",
                "Atenção!", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            // Se optar por "Sim", apagar:
            if (resposta == DialogResult.Yes)
            {
                libCompras.Items.Clear();
            }

        }

        private void btnExcluir_Click(object sender, EventArgs e)
        {
            // Verificar se o usuario não selecionou nada:
            if (libCompras.SelectedIndex == -1)
            {
                MessageBox.Show("Selecione um item para temover!",
                 "Erro!", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                // Salvar temporariamente o nome do item que sera removido:
                string itemRemovido = libCompras.SelectedItem.ToString();

                // Remover o item selecionado:
                libCompras.Items.RemoveAt(libCompras.SelectedIndex);


                MessageBox.Show("O item foi removido da lista!",
                   "show!", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

        }

        private void txbProduto_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            { 
                btnAdicionar.PerformClick();
            }

        }
    }
}
    
