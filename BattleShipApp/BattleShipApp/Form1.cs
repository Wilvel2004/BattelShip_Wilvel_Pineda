using BattleShipApp.model;
using BattleShipApp.utils;
using System;

namespace BattleShipApp
{
    public partial class Form1 : Form
    {
        public static Consola console;
        public Form1()
        {
            InitializeComponent();
            console = Consola.GetInstance(txtConsola);
        }

        private void btnMain1_Click(object sender, EventArgs e)
        {
            Coordinate c1 = new Coordinate(7, 5);
            Coordinate c2 = new Coordinate(-6, 3);
            Coordinate c2a = new Coordinate(7, 5);
            Coordinate c3 = c1.Add(c2);
            Coordinate c4 = c1.Substract(c2);
            Coordinate c5 = new Coordinate(c2);
            Coordinate[] vc1 = new Coordinate[5];
            for (int i = 0; i < vc1.Length; i++)
            {
                vc1[i] = new Coordinate(i, 5 - i);
            }
            console.WriteLine($"c1.x: {c1.Get(0)} c1.y: {c1.Get(1)}");
            console.WriteLine($"c2: {c2}");
            console.WriteLine();
            console.WriteLine($"c1.Equals(c2) = {c1.Equals(c2)}");
            console.WriteLine($"c1.Equals(c2) = {c1.Equals(c2a)}");
            console.WriteLine($"c3 (c1+c2): {c3}");
            console.WriteLine($"c4 (c1-c2): {c4}");
            console.WriteLine();
            console.WriteLine($"c5 Coordinate(c2): {c5}");
            console.WriteLine();
            for (int i = 0; i < vc1.Length; i++)
            {
                console.Write($"vc1[{i}]: {vc1[i]} ");
            }
            console.WriteLine();

            console.WriteLine($"c1.hashcode: {c1.GetHashCode()}");
            console.WriteLine($"c2.hashcode: {c2.GetHashCode()}");
            console.WriteLine($"c3.hashcode: {c3.GetHashCode()}");
            console.WriteLine($"c4.hashcode: {c4.GetHashCode()}");
            console.WriteLine($"c5.hashcode: {c5.GetHashCode()}");

            for (int i = 0; i < vc1.Length; i++)
            {
                console.Write($"vc1[{i}]: {vc1[i].GetHashCode()} ");
            }
            console.WriteLine();

            Coordinate c6 = new Coordinate(2, 1);
            Coordinate c7 = new Coordinate(1, 2);
            console.WriteLine($"c6.hashcode: {c6.GetHashCode()}");
            console.WriteLine($"c7.hashcode: {c7.GetHashCode()}");
        }
    }
}