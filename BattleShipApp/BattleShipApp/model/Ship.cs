using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BattleShipApp.model
{
    public class Ship
    {
        public static readonly int BOUNDING_SQUARE_SIZE = 5;
        public static readonly int HIT_VALUE = -1;
        public static readonly int CRAFT_VALUE = 1;

        private Orientation orientation;
        private char symbol;
        private string name;
        private Coordinate position;
        private int[][] shape;

        public Ship(Orientation orientation, char symbol, string name)
        {
            this.orientation = orientation;
            this.symbol = symbol;
            this.name = name;

            this.shape = new int[][]
            {
                new int[] {
                    0, 0, 0, 0, 0, // NORTH .....
                    0, 0, 1, 0, 0, // ..#..
                    0, 0, 1, 0, 0, // ..#..
                    0, 0, 1, 0, 0, // ..#..
                    0, 0, 0, 0, 0 // .....
                },
                new int[] {
                    0, 0, 0, 0, 0, // EAST .....
                    0, 0, 0, 0, 0, // .....
                    0, 1, 1, 1, 0, // .###.
                    0, 0, 0, 0, 0, // .....
                    0, 0, 0, 0, 0 // .....
                },
                new int[] {
                    0, 0, 0, 0, 0, // SOUTH .....
                    0, 0, 1, 0, 0, // ..#..
                    0, 0, 1, 0, 0, // ..#..
                    0, 0, 1, 0, 0, // ..#..
                    0, 0, 0, 0, 0 // .....
                },
                new int[] {
                    0, 0, 0, 0, 0, // WEST .....
                    0, 0, 0, 0, 0, // .....
                    0, 1, 1, 1, 0, // .###.
                    0, 0, 0, 0, 0, // .....
                    0, 0, 0, 0, 0 // .....
                }
            };
        }
        public Coordinate GetPosicion()
        {
            if(position == null)
            {
                return null;
            }
            else
            {
                return position.Copy();
            }
        }

        public void SetPosition(Coordinate pos)
        {
            this.position = position.Copy();
        }

        public Coordinate getPosition() { return position; }

        public string getName() { return name; }

        public Orientation getOrientation() { return orientation; }

        public char getSymbol() { return  symbol; }

        public int[][] getShape() { return shape; }

        public int GetShapeIndex(Coordinate pos)
        {
            return pos.Get(1) * BOUNDING_SQUARE_SIZE + pos.Get(0);
        }
        public HashSet<Coordinate> GetAbsolutePosition(Coordinate c)
        {
            HashSet<Coordinate> result = new HashSet<Coordinate>();
            for(int row = 0;row < BOUNDING_SQUARE_SIZE;row++)
            {
                int fila = BOUNDING_SQUARE_SIZE*row;
                for(int col = 0;col < BOUNDING_SQUARE_SIZE;col++)
                {
                    if (shape[(int)orientation][col + fila] != 0)
                    {
                        //Coordinate coor = new Coordinate(row,col);
                        result.Add(c.Add(new Coordinate(col,fila)));
                    }
                }
            }
            return result;
        }

        public HashSet<Coordinate> GetAbsolutePosition()
        {
            return GetAbsolutePosition(this.GetPosicion());
        }

        public bool Hit(Coordinate c)
        {
            HashSet<Coordinate> coordinates = GetAbsolutePosition();

            if (coordinates.Contains(c))
            {
                Coordinate csubs = c.Substract(position);

                if (shape[(int)orientation][GetShapeIndex(csubs)] == HIT_VALUE)
                {
                    return false;
                }
                else
                {
                    shape[(int)orientation][GetShapeIndex(csubs)] = HIT_VALUE;
                    return true;
                }
            }
            return false;
        }
        public bool IsHit(Coordinate c)
        {
            HashSet<Coordinate> coordinates = GetAbsolutePosition();

            if (coordinates.Contains(c))
            {
                Coordinate csubs = c.Substract(position);

                if (shape[(int)orientation][GetShapeIndex(csubs)] == HIT_VALUE)
                {
                    return true;
                }
             
            }
            return false;
        }
        public bool isShotDown()
        {
            foreach(Coordinate c in GetAbsolutePosition())
            {
                if(!IsHit(c)) return false;

            }
            return true;
        }
        public override string ToString()
        {
            string rn = "\r\n";
            string chart = $"{name} {orientation}{rn}";
            chart += $" -----{rn}";

            for(int row = 0;row <BOUNDING_SQUARE_SIZE;row++)
            {
                int fila = row * BOUNDING_SQUARE_SIZE;
                chart += "|";
                for (int col = 0;col < BOUNDING_SQUARE_SIZE; col++)
                {
                    if (shape[(int)orientation][col + fila] == CRAFT_VALUE)
                    {
                        chart+= symbol;
                    }else if(shape[(int)orientation][col + fila] == HIT_VALUE)
                    {
                        chart += Board.HIT_SYMBOL;
                    }
                    else
                    {
                        chart += Board.WATER_SYMBOL;
                    }
                }
                chart += $"|{rn}";
            }
            chart += $" -----";
            return chart;
        }
    }
}
