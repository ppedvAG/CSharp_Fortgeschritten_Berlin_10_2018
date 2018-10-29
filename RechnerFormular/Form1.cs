using RechnerContracts;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TaschenrechnerLibrary;

namespace RechnerFormular
{
    public partial class Form1 : Form
    {
        ErweiterbarerRechner _rechner;
        IParser _parser;
        BerechnungsAblauf _ablauf;

        public Form1()
        {
            InitializeComponent();
            _rechner = new ErweiterbarerRechner();
            _parser = new Parser();
            _ablauf = new BerechnungsAblauf(_rechner, _parser, () => tbAufgabe.Text, output => MessageBox.Show($"Ergebnis: {output}"));
        }

        private void Berechnungs_Button_Click(object sender, EventArgs e)
        {
            if (sender is Button button)
            {
                char symbol = button.Text[0];
                try
                {
                    double zahl1 = double.Parse(tbZahl1.Text);
                    double zahl2 = double.Parse(tbZahl2.Text);

                    double ergebnis = _rechner.Berechne(new Formel(zahl1, zahl2, symbol));
                    MessageBox.Show($"Ergebnis: {ergebnis}");
                }
                catch (Exception exp)
                {
                    MessageBox.Show(exp.Message);
                }
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            //string aufgabe = tbAufgabe.Text;
            //try
            //{
            //    IFormel formel = _parser.Parse(aufgabe);
            //    double ergebnis = _rechner.Berechne(formel);
            //    MessageBox.Show($"Ergebnis: {ergebnis}");
            //}
            //catch (Exception exp)
            //{
            //    MessageBox.Show(exp.Message);
            //}

            //Alternative
            _ablauf.StarteRechnerVorgang();
        }

        private void pluginLadenToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenFileDialog dialog = new OpenFileDialog();
            dialog.Filter = "Class Library|*.dll";
            if (dialog.ShowDialog() == DialogResult.OK)
            {
                string pluginFile = dialog.FileName;
                //Reflection: Plugin installieren
                Assembly plugin = Assembly.LoadFile(pluginFile);
                foreach (Type type in plugin.GetTypes())
                {
                    MessageBox.Show(type.FullName);
                    //Prüfung ob die in type beschriebene Klasse das Interface IRechenoperation implementiert
                    //if(type.GetInterface(nameof(IRechenoperation)) != null)
                    if (type.GetInterfaces().Contains(typeof(IRechenoperation)))
                    {
                        //Instanz in type beschriebenen Klasse bauen
                        IRechenoperation neueOperation = (IRechenoperation)Activator.CreateInstance(type);
                        //Prüfung ob Plugin bereits installiert wurde
                        if (!_rechner.Rechenoperationen.ContainsKey(neueOperation.Rechensymbol))
                        {
                            //Neue Rechenoperation zum Rechner-Objekt hinzufügen
                            _rechner.Rechenoperationen.Add(neueOperation.Rechensymbol, neueOperation);
                            //Neuen Button dynamisch generieren
                            Button neuerButton = new Button();
                            neuerButton.Text = neueOperation.Rechensymbol.ToString();
                            neuerButton.Click += Berechnungs_Button_Click;
                            panelButtons.Controls.Add(neuerButton);
                        }
                    }
                }
            }
        }
    }
}
