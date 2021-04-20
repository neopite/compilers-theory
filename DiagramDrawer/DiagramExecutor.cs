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
     public class DiagramExecutor
    {
        private static Microsoft.Msagl.Drawing.Graph _graph;
        private static Microsoft.Msagl.GraphViewerGdi.GViewer _viewer;
        private static System.Windows.Forms.Form _form;
        private static ColorAdapter _colorAdapter;
        private static LineArrowAdapter _arrowAdapter;
        
        public static void Setup()
        {
            _form = new System.Windows.Forms.Form();
            _viewer = new Microsoft.Msagl.GraphViewerGdi.GViewer();
            _graph = new Microsoft.Msagl.Drawing.Graph("graph");
            _colorAdapter = new ColorAdapter();
            _arrowAdapter = new LineArrowAdapter();

        }

        public static void ShowDiagram()
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