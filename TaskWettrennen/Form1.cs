using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TaskWettrennen
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        Random _random = new Random();
        const int Start_Position = 20;

        private void button1_Click(object sender, EventArgs e)
        {
            List<Fahrer> Fahrer = new List<Fahrer>()
            {
                new Fahrer(pictureBoxMichael, "Michael", 20),
                new Fahrer(pictureBoxVettel, "Vettel", 20)
            };

            Task.Run(() =>
            {
                var result = Parallel.ForEach(Fahrer, (fahrer, state) =>
                {
                    int zielPosLeft = pictureBoxZiel.Left;
                    while (fahrer.Box.Right < zielPosLeft)
                    {
                        Thread.Sleep(_random.Next(0, 5) * 10);
                        this.Invoke(new Action(() => fahrer.Box.Left += 3));
                    }
                    lock (this)
                    {
                        if (state.LowestBreakIteration == null)
                            state.Break();
                    }
                });

                MessageBox.Show($"Sieger: {Fahrer[(int)(result.LowestBreakIteration ?? 0)].Name}");
            });
        }

        private void button2_Click(object sender, EventArgs e)
        {
            List<Fahrer> Fahrer = new List<Fahrer>()
            {
                new Fahrer(pictureBoxMichael, "Michael", 20),
                new Fahrer(pictureBoxVettel, "Vettel", 20)
            };


            List<Task> tasks = new List<Task>();

            foreach (var item in Fahrer)
            {
                tasks.Add(Task.Run(() => FahreZumZiel(item)));
            }

            Task.Run(() =>
            {
                int sieger = Task.WaitAny(tasks.ToArray());
                MessageBox.Show($"Sieger: {Fahrer[sieger].Name}");
            });
        }

        private void FahreZumZiel(Fahrer fahrer)
        {
            int zielPosLeft = pictureBoxZiel.Left;
            while (fahrer.Box.Right < zielPosLeft)
            {
                Thread.Sleep(_random.Next(0, 5) * 10);
                this.Invoke(new Action(() => fahrer.Box.Left += 3));
            }
        }
    }

    public class Fahrer
    {
        public PictureBox Box { get; private set; }
        public string Name { get; private set; }

        public Fahrer(PictureBox box, string name, int startPosition)
        {
            Box = box;
            Name = name;
            Box.Left = startPosition;
        }

    }
}
