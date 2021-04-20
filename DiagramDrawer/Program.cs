using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using System.Windows.Forms;
using TheoryOfCompilators.SemanticalAnalyzer;
using Microsoft.Msagl.Drawing;
using TheoryOfCompilators.DiagramDrawer.Entitys;

namespace DiagramDrawer
{
    static class Program
    {
        private static Microsoft.Msagl.Drawing.Graph _graph;
        private static Microsoft.Msagl.GraphViewerGdi.GViewer _viewer;
        private static System.Windows.Forms.Form _form;
        private static ColorAdapter _colorAdapter;
        private static LineArrowAdapter _arrowAdapter;
        
        static void Main(string [] args)
        {
            Setup();
            CreateNode(new DiagramNode("node1", "circle", "red", "pink", 2));
            CreateNode(new DiagramNode("node2", "circle", "red", "green", 2));
            CreateEdge("node1", "node2", new DiagramLine("strela", 1, "red", "none"));
            ShowDiagram();
        }

        
        /*
         *
         * Edge edge = _graph.AddEdge("B", "C");
            _graph.AddEdge("A", "C").Attr.Color = Microsoft.Msagl.Drawing.Color.Green;
            _graph.FindNode("A").Attr.FillColor = Microsoft.Msagl.Drawing.Color.Magenta;
            _graph.FindNode("B").Attr.FillColor = Microsoft.Msagl.Drawing.Color.MistyRose;
            Microsoft.Msagl.Drawing.Node c = _graph.FindNode("C");
            edge.Attr.Color = Color.Aqua;
            edge.Attr.ArrowheadAtTarget = ArrowStyle.Generalization;
            edge.LabelText = "fe";
            c.Attr.FillColor = Microsoft.Msagl.Drawing.Color.PaleGreen;
            c.Attr.Shape = Microsoft.Msagl.Drawing.Shape.House;
            
         */
        
        private static void Setup()
        {
            _form = new System.Windows.Forms.Form();
            _viewer = new Microsoft.Msagl.GraphViewerGdi.GViewer();
            _graph = new Microsoft.Msagl.Drawing.Graph("graph");
            _colorAdapter = new ColorAdapter();
            _arrowAdapter = new LineArrowAdapter();

        }

        private static void ShowDiagram()
        {
            //bind the graph to the viewer 
            _viewer.Graph = _graph;
            //associate the viewer with the form 
            _form.SuspendLayout();
            _viewer.Dock = System.Windows.Forms.DockStyle.Fill;
            _form.Controls.Add(_viewer);
            _form.ResumeLayout();
            //show the form 
            _form.ShowDialog();
        }

        public static Node CreateNode(DiagramNode node)
        {
            Node newNode = new Node(node.Name);
            newNode.Attr.Shape = Shape.Box;
            newNode.Attr.FillColor=_colorAdapter.Adapt(node.FillColor);
            newNode.Attr.Color = _colorAdapter.Adapt(node.DrawColor);
            newNode.LabelText = node.Name;
            _graph.AddNode(newNode);
            return newNode;
        }

        public static Edge CreateEdge(string from, string to, DiagramLine lineBetween)
        {
            Edge edge = _graph.AddEdge(from, to);
            edge.Attr.Color = _colorAdapter.Adapt(lineBetween.DrawColor);
            edge.Attr.LineWidth = lineBetween.Width;
            edge.Attr.ArrowheadAtSource = _arrowAdapter.Adapt(lineBetween.Arrow);
            return edge;
        }
        
    }
}