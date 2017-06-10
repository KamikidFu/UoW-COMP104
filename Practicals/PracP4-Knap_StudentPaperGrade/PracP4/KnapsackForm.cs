using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.IO;

namespace PracP4
{
    public partial class KnapsackForm : Form
    {
        //#####################################################################
        //# Instance Variables
        private BindingList<Container> containers_ = new BindingList<Container>();
        private BindingList<Item> unpackedItems_ = new BindingList<Item>();

        //#####################################################################
        //# Constructor
        public KnapsackForm()
        {
            InitializeComponent();

            Container handbag = new Container("Handbag", 4.0, 300.0);
            handbag.Add(new Item("Diamond earring", 0.002, 2.0, 580.00m));
            handbag.Add(new Item("Lipstick", 0.025, 10.0, 8.90m));
            containers_.Add(handbag);

            Container suitcase = new Container("Suitcase", 20.0, 45000.0);
            suitcase.Add(new Item("Laptop", 3.25, 3070.0, 1580.00m));
            suitcase.Add(new Item("White pants", 0.75, 1500.0, 64.50m));
            suitcase.Add(new Item("Black shirt", 0.45, 450.0, 49.50m));
            containers_.Add(suitcase);

            unpackedItems_.Add(new Item("Smartphone", 0.17, 69.0, 620.00m));
            unpackedItems_.Add(new Item("Coffee mug", 0.4, 121.0, 4.80m));
            unpackedItems_.Add(new Item("Chocolate", 0.25, 200.0, 7.50m));
            unpackedItems_.Add(new Item("White socks", 0.085, 225.0, 9.95m));

            //Use method to update labels
            updateLabels();

            //Datagrid shows value
            dataGridView1_unpackedItems.DataSource = unpackedItems_;
            dataGridView2_containers.DataSource = containers_;
            dataGridView3_packedItems.DataSource = containers_[0].Contents;
        }
        /// <summary>
        /// Task 2, use a method to update labels
        /// </summary>
        private void updateLabels()
        {
            //Declare varibles
            double weight = 0.0d, volume = 0.0d;
            decimal value = 0.0m;
            //Loop for collecting data
            for (int i = 0; i < containers_.Count; i++)
            {
                weight += containers_[i].PackedWeight;
                volume += containers_[i].PackedVolume;
                value += containers_[i].PackedValue;
            }
            //Show the result
            packedWeightLabel_.Text = weight.ToString();
            packedVolumeLabel_.Text = volume.ToString();
            packedValueLabel_.Text = value.ToString("c");

        }

        /// <summary>
        /// Task 3 Event handler
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void dataGridView2_containers_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                int index = dataGridView2_containers.CurrentCell.RowIndex;
                dataGridView3_packedItems.DataSource = containers_[index].Contents;
            }
            catch
            {
                MessageBox.Show("Error: Selecting occurs error!");
            }
        }

        /// <summary>
        /// Remove the thing selected
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void removeButton__Click(object sender, EventArgs e)
        {
            try
            {
                int indexItem = dataGridView3_packedItems.CurrentCell.RowIndex;
                int indexContainer= dataGridView2_containers.CurrentCell.RowIndex;

                //Choose the right things?
                if (indexItem<0)
                {
                    MessageBox.Show("No item selected!");
                    return;
                }
                if(indexContainer<0)
                {
                    MessageBox.Show("No container selected!");
                    return;
                }
                
                //Make a new item object and remove it from containers' list and add to unpakced item list
                Item i1 = containers_[indexContainer].Contents[indexItem];
                containers_[indexContainer].Contents.RemoveAt(indexItem);
                unpackedItems_.Add(i1);
                updateLabels();
                updateDataGrid();
            }
            catch
            {
                MessageBox.Show("Error: removing occurs error.");
            }
        }

        private void updateDataGrid()
        {
            dataGridView1_unpackedItems.DataSource = null;
            dataGridView2_containers.DataSource = null;
            dataGridView1_unpackedItems.DataSource = unpackedItems_;
            dataGridView2_containers.DataSource = containers_;
        }

        /// <summary>
        /// Add button to add item to a container
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void addButton__Click(object sender, EventArgs e)
        {
            try
            {
                int indexItem = dataGridView1_unpackedItems.CurrentCell.RowIndex;
                int indexContainer = dataGridView2_containers.CurrentCell.RowIndex;
                Item i1 = unpackedItems_[indexItem];

                //Choose the right things?
                if (indexItem < 0)
                {
                    MessageBox.Show("No item selected!");
                    return;
                }
                if (indexContainer < 0)
                {
                    MessageBox.Show("No container selected!");
                    return;
                }

                if (i1.Weight <(containers_[indexContainer].MaxWeight - containers_[indexContainer].PackedWeight) &&
                    i1.Volume < (containers_[indexContainer].MaxVolume - containers_[indexContainer].PackedVolume))
                {
                    //Set up a new and remove it now
                    unpackedItems_.RemoveAt(indexItem);
                    containers_[indexContainer].Add(i1);
                }
                else
                {
                    MessageBox.Show("The contain " + containers_[indexContainer].Name + " could not add " + unpackedItems_[indexItem].Name + ".");
                }

                updateLabels();
                updateDataGrid();
            }
            catch
            {
                MessageBox.Show("Error: adding occurs error!");
            }

            

        }

        private void openButton__Click(object sender, EventArgs e)
        {
            StreamReader reader;
            openFileDialog1.Filter = "CSV Files| *.csv";
            try
            {
                if (openFileDialog1.ShowDialog() == DialogResult.OK)
                {
                    reader = File.OpenText(openFileDialog1.FileName);
                    unpackedItems_.Clear();
                    containers_.Clear();
                    dataGridView3_packedItems.DataSource = null;
                    while (!reader.EndOfStream)
                    {
                        string[] oneLineData = reader.ReadLine().Split(',');
                        if (oneLineData.Length == 5)
                        {
                            if (oneLineData[0] == "ITEM")
                            {
                                Item i1 = new Item(oneLineData[1], double.Parse(oneLineData[2]),
                                                   double.Parse(oneLineData[3]), decimal.Parse(oneLineData[4]));
                                unpackedItems_.Add(i1);
                            }
                        }
                        else if (oneLineData.Length == 4) 
                        {
                            
                            if (oneLineData[0] == "CONTAINER")
                            {
                                Container c1 = new Container(oneLineData[1], double.Parse(oneLineData[2]), double.Parse(oneLineData[3]));
                                containers_.Add(c1);
                            }
                        }
                    }
                    reader.Close();
                }
                updateLabels();
                updateDataGrid();
            }
            catch { MessageBox.Show("Error!"); }

        }

        /// <summary>
        /// Auto pack things
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button_autoPack_Click(object sender, EventArgs e)
        {
            //for (int i = 0; i < containers_.Count; i++)
            //{
            //    for (int j = 0; j < containers_[i].Contents.Count; j++)
            //    {
            //        Item i1 = containers_[i].Contents[j];
            //        if ((containers_[i].MaxWeight - containers_[i].PackedWeight - i1.Weight) >= 0)
            //        {
            //        }
            //    }
            //}

            //decimal packedValue = 0.0m;
            //List<Item> packedItemList = new List<Item>();
            //for(int i=0;i<unpackedItems_.Count;i++)
            //{
            //    Item i1 = unpackedItems_[i];
            //    for (int j=0;j<containers_[j].MaxWeight;j++)
            //    {
            //        for (int k = 0; k < containers_[j].MaxVolume; k++)
            //        {
            //            if ((containers_[j].MaxWeight - containers_[j].PackedWeight - i1.Weight) >= 0 &&
            //                (containers_[j].MaxVolume - containers_[j].PackedVolume - i1.Volume) >= 0)
            //            {
            //                containers_[j].Add(i1);
            //                packedItemList.Add(i1);
            //            }
            //        }
            //    }
            //}
            //updateLabels();

           
            decimal currentValue = 0.0m;
            decimal previousValue = 0.0m;
            double packedWeight = 0.0d;
            double packedVolume = 0.0d;
            for (int i=0;i<unpackedItems_.Count;i++)
            {
                Item currentItem = unpackedItems_[i];
                if(i>0)
                {
                    Item previousItem = unpackedItems_[i - 1];
                }
                for (int j = 0; j < containers_.Count; j++)
                {
                    double currentWeight = containers_[j].MaxWeight-packedWeight;
                    double currentVolume = containers_[j].MaxVolume-packedVolume;
                    if (currentItem.Weight <= currentWeight &&
                        currentItem.Volume <= currentVolume)
                    {
                        packedWeight += currentItem.Weight;
                        packedVolume += currentItem.Volume;
                        currentValue += currentItem.Value;
                        containers_[j].Contents.Add(currentItem);
                        break;
                        //现在是装的下就装下去，装不下换下一个看能不能装
                        //if (previousValue<currentValue)
                        //{
                        //    packedWeight += currentItem.Weight;
                        //    packedVolume += currentItem.Volume;
                        //    containers_[j].Contents.Add(currentItem);
                        //    previousValue = currentValue;
                        //    break;
                        //}

                    }
                    else
                    {
                        dataGridView3_packedItems.DataSource = containers_[j].Contents;
                    }                    
                }                
            }
            updateDataGrid();
            updateLabels();
            for(int i =0;i<containers_.Count;i++)
            {
                for(int j=0;j<containers_[i].Contents.Count;j++)
                {
                    Item j1 = containers_[i].Contents[j];
                    for(int k=0;k<unpackedItems_.Count;k++)
                    {
                        Item k1 = unpackedItems_[k];
                        if(j1 == k1)
                        {
                            unpackedItems_.RemoveAt(k);
                        }
                    }
                }
            }

        }
    }
}
