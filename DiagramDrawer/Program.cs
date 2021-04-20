using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using TheoryOfCompilators.SemanticalAnalyzer;
using Microsoft.Msagl.Drawing;
using TheoryOfCompilators.DiagramDrawer.Entitys;

namespace DiagramDrawer
{
    static class Program
    {
        private static Microsoft.Msagl.Drawing.Graph graph;
        private static Microsoft.Msagl.GraphViewerGdi.GViewer viewer;
        private static System.Windows.Forms.Form form;
        
        static void Main(string [] args)
        {
            Setup();
            
            Edge edge = graph.AddEdge("B", "C");
            graph.AddEdge("A", "C").Attr.Color = Microsoft.Msagl.Drawing.Color.Green;
            graph.FindNode("A").Attr.FillColor = Microsoft.Msagl.Drawing.Color.Magenta;
            graph.FindNode("B").Attr.FillColor = Microsoft.Msagl.Drawing.Color.MistyRose;
            Microsoft.Msagl.Drawing.Node c = graph.FindNode("C");
            edge.Attr.Color = Color.Aqua;
            edge.Attr.ArrowheadAtTarget = ArrowStyle.Generalization;
            edge.LabelText = "fe";
            c.Attr.FillColor = Microsoft.Msagl.Drawing.Color.PaleGreen;
            c.Attr.Shape = Microsoft.Msagl.Drawing.Shape.House;
            
            ShowDiagram();
        }

        private static void Setup()
        {
            System.Windows.Forms.Form form = new System.Windows.Forms.Form();
            Microsoft.Msagl.GraphViewerGdi.GViewer viewer = new Microsoft.Msagl.GraphViewerGdi.GViewer();
            Microsoft.Msagl.Drawing.Graph graph = new Microsoft.Msagl.Drawing.Graph("graph");
        }

        private static void ShowDiagram()
        {
            //bind the graph to the viewer 
            viewer.Graph = graph;
            //associate the viewer with the form 
            form.SuspendLayout();
            viewer.Dock = System.Windows.Forms.DockStyle.Fill;
            form.Controls.Add(viewer);
            form.ResumeLayout();
            //show the form 
            form.ShowDialog();
        }

        public static Node CreateNode(DiagramNode node)
        {
            Node newNode = new Node(node.Name);
            newNode.Attr.Shape = Shape.Box;
            newNode.Attr.FillColor=Color.Aqua;
            newNode.LabelText = node.Name;
            graph.AddNode(newNode);
            return newNode;
        }
    }
}