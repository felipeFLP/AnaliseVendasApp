using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Diagnostics;
using AnaliseVendasApp.Negocio;
using System.Collections;
using AnaliseVendasApp.Dados;
using Microsoft.EntityFrameworkCore;

namespace AnaliseVendasApp
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }

        public IList lClientes = new List<Cliente>();
        public IList lVendedores = new List<Vendedor>();
        public IList lVendas = new List<Venda>();

        string homePath = Path.GetDirectoryName(Path.GetDirectoryName(System.IO.Directory.GetCurrentDirectory()));
                            

        private void CheckFile(string filePath)
        {

            ClearEntyties();

            string[] lines = File.ReadAllLines(filePath);

            foreach (string line in lines)
            {

                string[] splittedLine = line.Split('�');

                switch (splittedLine[0])
                {
                    case "001": // VENDEDOR
                        Vendedor pf = new Vendedor(splittedLine[1], splittedLine[2], Convert.ToDouble(splittedLine[3]));
                        AdicionaVendedor(pf);

                        break;

                    case "002": // CLIENTE
                        Cliente pj = new Cliente(splittedLine[1], splittedLine[2], splittedLine[3]);
                        AdicionaCliente(pj);
                        break;

                    case "003": // VENDA

                        // split dos items e retorna uma lista de items

                        List<ItemObjeto> itemsObj = GetItemsFromArray(splittedLine[2]);

                        string nomeVendedor = splittedLine[3];
                        Vendedor vendedor = GetVendedorByName(nomeVendedor);

                        int idVenda = Convert.ToInt32(splittedLine[1]);
                        Venda venda = new Venda(idVenda, vendedor);

                        VendaItem vendaItem;
                        IList<VendaItem> vendasDeItens = new List<VendaItem>();


                        Item item;
                        try
                        {
                            using (var contexto = new AnaliseVendasContexto())
                            {

                                foreach (var itemObj in itemsObj)
                                {
                                    if (validaItem(itemObj.id))
                                    {
                                        item = new Item(itemObj.id);
                                        contexto.Items.Add(item);
                                        contexto.SaveChanges();
                                    }                                        
                                    else
                                        item = contexto.Items.Find(itemObj.id);

                                        vendaItem = new VendaItem();
                                    
                                    vendaItem.Item = item;
                                    vendaItem.Venda = venda;
                                    vendaItem.Quantity = itemObj.quantidade;
                                    vendaItem.Price = itemObj.preco;

                                    vendasDeItens.Add(vendaItem);

                                    
                                    
                                }

                                venda.Items = vendasDeItens;

                                contexto.Vendas.Add(venda);
                                contexto.Vendedores.Attach(vendedor);

                                contexto.SaveChanges();




                            }

                ;
                        }
                        catch (Exception ex)
                        {

                            Console.WriteLine(ex.Message);
                            Console.WriteLine(ex.InnerException.ToString());
                        }                        

                        break;

                    default:
                        break;
                }
                foreach (var param in splittedLine)
                {
                    Console.WriteLine(param);
                }


            }


        }

        private bool validaItem(int id)
        {
            try
            {
                using (var contexto = new AnaliseVendasContexto())
                {
                    foreach (var item in contexto.Items)
                    {
                        if (item.Id == id)
                        {
                            return false;
                        }
                    }
                }
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            return false;
        }

        private void ClearEntyties()
        {
            try
            {
                using (var contexto = new AnaliseVendasContexto())
                {
                    foreach (var cliente in contexto.Clientes)
                    {
                        contexto.Remove(cliente);
                    }

                    foreach (var vendedor in contexto.Vendedores)
                    {
                        contexto.Remove(vendedor);
                    }

                    foreach (var item in contexto.Items)
                    {
                        contexto.Remove(item);
                    }

                    foreach (var venda in contexto.Vendas)
                    {
                        contexto.Remove(venda);
                    }

                    foreach (var vendaItem in contexto.VendasItems)
                    {
                        contexto.Remove(vendaItem);
                    }

                    contexto.SaveChanges();

                }

                
                
            }
            catch (Exception)
            {

                throw;
            }
        }

        private Vendedor GetVendedorByName(string v)
        {
            try
            {
                using (var contexto = new AnaliseVendasContexto())
                {
                    Vendedor vendedor = contexto.Vendedores.Where(ve => ve.Name == (v)).First();
                    return vendedor;
                }

                ;
            }
            catch (Exception ex)
            {

                return null;
            }
        }

        private List<ItemObjeto> GetItemsFromArray(string line)
        {
            List<ItemObjeto> itemsOutput = new List<ItemObjeto>();
            string[] splittedItems = line.Replace("[", "").Replace("]", "").Split(',');

            foreach (var i in splittedItems)
            {
                string[] splittedValues = i.Split('-');
                if (splittedValues.Length > 0)
                {
                    itemsOutput.Add(
                        new ItemObjeto()
                        {
                            id = Convert.ToInt32(splittedValues[0]),
                            quantidade = Convert.ToInt32(splittedValues[1]),
                            preco = Convert.ToDouble(splittedValues[2].Replace('.',','))
                        }
                    );
                      
                }


            }

            return itemsOutput;

        }

        private void AdicionaVendedor(Vendedor vendedor)
        {
            try
            {
                using (var contexto = new AnaliseVendasContexto())
                {
                    contexto.Vendedores.Add(vendedor);
                    contexto.SaveChanges();
                }

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        private void AdicionaCliente(Cliente cliente)
        {
            try
            {
                using (var contexto = new AnaliseVendasContexto())
                {
                    contexto.Clientes.Add(cliente);
                    contexto.SaveChanges();
                }

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        private void AdicionaItem(Item item)
        {
            try
            {
                using (var contexto = new AnaliseVendasContexto())
                {
                    contexto.Items.Add(item);
                    contexto.SaveChanges();
                }

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        private void AdicionaVendaItem(VendaItem vendaItem)
        {
            try
            {
                using (var contexto = new AnaliseVendasContexto())
                {
                    contexto.VendasItems.Add(vendaItem);
                    contexto.SaveChanges();
                }

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        private void AdicionaVenda(Venda venda)
        {
            try
            {
                using (var contexto = new AnaliseVendasContexto())
                {
                    contexto.Vendas.Add(venda);
                    contexto.SaveChanges();
                }

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
        
        private void MainForm_Load(object sender, EventArgs e)
        {
            string filesPathIn = homePath + "\\data\\In";

            try
            {
                fsw1.Path = filesPathIn;
                fsw1.Filter = "*.txt";

                fsw1.NotifyFilter = NotifyFilters.FileName | NotifyFilters.DirectoryName | NotifyFilters.CreationTime;

                fsw1.EnableRaisingEvents = true;

                CheckForIllegalCrossThreadCalls = false;

                WaitForChangedResult wcr = fsw1.WaitForChanged(WatcherChangeTypes.All, 10000);

                if (wcr.TimedOut)

                {

                    Console.WriteLine("Já se passaram 10 segundos do evento");

                }

                else

                {

                    Console.WriteLine("Evento: " + wcr.Name, wcr.ChangeType.ToString());

                }




            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

        }

        private void fsw1_Created(object sender, FileSystemEventArgs e)
        {
            txtOutput.Text += String.Format("Novo arquivo: {0} {1}", e.FullPath, Environment.NewLine);


            txtOutput.Text += String.Format("Analisando arquivo na pasta In...{0}", Environment.NewLine);
            CheckFile(e.FullPath);
            txtOutput.Text += String.Format("Analisando dados das vendas...{0}", Environment.NewLine);
            string[] values = GetSalesAnalisys();
            txtOutput.Text += String.Format("Gerando arquivo de saída na pasta Out...{0}", Environment.NewLine);
            WriteOutputMessage(values[0], values[1], values[2], values[3]);
            txtOutput.Text += String.Format("----------------------FIM----------------------{0}", Environment.NewLine);
            
        }

        private string[] GetSalesAnalisys()
        {
            string[] valores = new string[4];

            try
            {
                using (var contexto = new AnaliseVendasContexto())
                {

                    valores[0] = contexto.Clientes.Count().ToString();
                    valores[1] = contexto.Vendedores.Count().ToString();
                    
                    // encontra o id da venda que mais faturou
                    var vendas = contexto.Vendas
                        .Include(v => v.Items);

                    double total = 0;
                    int id = -1;
                    double maxTotal = 0;
                    int maxId = 0;
                    foreach (var venda in vendas)
                    {
                        id = venda.Id;
                        List<VendaItem> items = venda.Items.ToList();
                        foreach (var item in items)
                        {
                            total = item.Price * item.Quantity;
                        }

                        if (total > maxTotal)
                        {
                            maxId = id;
                            maxTotal = total;
                        }
                    }
                    Console.WriteLine("ID que mais vendeu foi: "+maxId);
                    valores[2] = maxId.ToString();
                    //



                    // verifica qual foi o vendedor com pior venda
                    total = 0;
                    id = -1;
                    double minTotal = 99999999999;
                    int minId = 0;
                    foreach (var venda in vendas)
                    {
                        id = venda.Id;
                        List<VendaItem> items = venda.Items.ToList();
                        foreach (var item in items)
                        {
                            total = item.Price * item.Quantity;
                        }

                        if (total < minTotal)
                        {
                            minId = id;
                            minTotal = total;
                        }
                    }
                    string vendedor = "";

                    
                    var vendasDeVendedores = contexto.Vendas
                        .Include(v => v.Vendedor);

                    foreach (var venda in vendasDeVendedores)
                    {
                        if (venda.Id == minId)
                        {
                            vendedor = venda.Vendedor.Name;
                        }
                    }


                    Console.WriteLine("Vendedor que menos vendeu: " + vendedor);
                    valores[3] = vendedor;
                }
            }
            catch (Exception ex)
            {
                
            }
            

            return valores;
        }

        private void WriteOutputMessage(string paramClientes, string paramVendedores, string paramIdVenda, string paramPiorVendedor)
        {
            string path = homePath + "\\data\\Out\\output.txt";
            using (StreamWriter sw = new StreamWriter(path))
            {

                sw.WriteLine("Número de clientes: " + paramClientes);
                sw.WriteLine("Número de vendedores: " + paramVendedores);
                sw.WriteLine("Venda mais cara: ID (" + paramIdVenda +")");
                sw.WriteLine("Pior vendedor: " + paramPiorVendedor);
                
            }


        }
    }

    public class ItemObjeto
    {
        public int id;
        public int quantidade;
        public double preco;
    }


}
