using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MultiObjectiveEA
{
    class Edge
    {
        // Attributes
        int[] vertices;
        int danger;
        int distance;

        public int[] Vertices
        {
            get { return vertices; }
            set { vertices = value; }
        }
        

        public int Danger
        {
            get { return danger; }
            set { danger = value; }
        }
        

        public int Distance
        {
            get { return distance; }
            set { distance = value; }
        }

        // Methods

        public Edge(int originVertex, int destinationVertex)
        {
            this.vertices = new int[2]{originVertex, destinationVertex};
            this.distance = -1;
            this.danger = -1;
        }

        public Edge(int[] edge, int dist, int dang)
        {
            this.vertices = edge;
            this.distance = dist;
            this.danger = dang;
        }

    }
}
