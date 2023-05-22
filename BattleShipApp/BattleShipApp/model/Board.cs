using BattleShipApp.model;
using BattleShipApp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BattleShip.model
{
    public class Board
    {
        public static readonly char HIT_SYMBOL = '•';
        public static readonly char WATER_SYMBOL = ' ';
        public static readonly char NOTSEEN_SYMBOL = '?';
        private static readonly int MIN_BOARD_SIZE = 5;
        private static readonly int MAX_BOARD_SIZE = 20;

        private Dictionary<Coordinate, Ship> board;
        private HashSet<Coordinate> seen;
        private int size;
        private int numCrafts;
        private int destroyedCrafts;

        public Board(int size)
        {
            numCrafts = 0;
            destroyedCrafts = 0;

            board = new Dictionary<Coordinate, Ship>();
            seen = new HashSet<Coordinate>();

            if (size < MIN_BOARD_SIZE || size > MAX_BOARD_SIZE)
            {
                //Form1.console.WriteLine("Size is not in Board size.");
                this.size = MIN_BOARD_SIZE;
            }
            else
                this.size = size;
        }

        public bool CheckCoordinate(Coordinate c)
        {
            if (c.Get(0) >= 0 && c.Get(0) < size && c.Get(1) >= 0 && c.Get(1) < size)
                return true;
            return false;
        }

        public bool AddShip(Ship ship, Coordinate position)
        {
            HashSet<Coordinate> coords = ship.GetAbsolutePositions(position);

            // Check if all positions are in the board.
            foreach (Coordinate c in coords)
                if (!CheckCoordinate(c))
                {
                    //Form1.console.WriteLine($"Coordinate {c} is out of bounds.");
                    return false;
                }

            // Check if all coords aren't ocupied.
            foreach (Coordinate c in coords)
                if (board.ContainsKey(c))
                {
                    //Form1.console.WriteLine($"Coordinate {c} is already ocupied.");
                    return false;
                }

            // Check thtat there are not neighbors.
            HashSet<Coordinate> neighbors = GetNeighborhood(ship, position);
            foreach (Coordinate c in neighbors)
            {
                if (GetShip(c) != null)
                {
                    //Form1.console.WriteLine($"Coordinate {c} is in a neighbor coordinate.");
                    return false;
                }
            }

            // Adding the ship to the board.
            ship.SetPosition(position);
            foreach (Coordinate c in coords)
            {
                board.Add(c, ship);
            }

            numCrafts++;
            return true;
        }

        public Ship GetShip(Coordinate c)
        {
            if (board.ContainsKey(c))
                return board[c];
            else
                return null;
        }

        public int GetSize()
        {
            return this.size;
        }

        public bool IsSeen(Coordinate c)
        {
            return seen != null && seen.Contains(c);
        }

        public CellStatus Hit(Coordinate c)
        {
            // Check if coordinate isn't in the board.
            if (!CheckCoordinate(c))
            {
                Form1.console.WriteLine($"Coordinate {c} is out of bounds.");
                return CellStatus.WATER;
            }
            else
            {
                seen.Add(c);

                Ship ship = GetShip(c);
                if (ship == null)
                    return CellStatus.WATER;
                else
                {
                    if (ship.Hit(c))    // Is hitted
                    {
                        if (ship.IsShotDown())
                        {
                            HashSet<Coordinate> neighbors = GetNeighborhood(ship);
                            foreach (Coordinate coord in neighbors)
                            {
                                seen.Add(coord);
                            }

                            destroyedCrafts++;
                            return CellStatus.DESTROYED;
                        }
                        else
                            return CellStatus.HIT;
                    }
                    else     // Isn't hitted
                        return CellStatus.WATER;
                }
            }
        }

        public bool AreAllCraftsDestroyed()
        {
            return numCrafts == destroyedCrafts;
        }

        public HashSet<Coordinate> GetNeighborhood(Ship ship, Coordinate position)
        {
            HashSet<Coordinate> coordinates = new HashSet<Coordinate>();

            foreach (Coordinate coord in ship.GetAbsolutePositions(position))
                foreach (Coordinate coordAux in coord.AdjacentCoordinates())
                    if (CheckCoordinate(coordAux))
                        coordinates.Add(coordAux);

            foreach (Coordinate coord in ship.GetAbsolutePositions(position))
                coordinates.Remove(coord);

            return coordinates;
        }

        public HashSet<Coordinate> GetNeighborhood(Ship ship)
        {
            return GetNeighborhood(ship, ship.GetPosition());
        }

        public string Show(bool unveil)
        {
            string rn = "\r\n";
            string tablero = "";

            for (int y = 0; y < size; y++)
            {
                for (int x = 0; x < size; x++)
                {
                    Coordinate c = new Coordinate(x, y);
                    if (unveil)
                    {
                        Ship ship = GetShip(c);
                        if (ship != null)
                        {
                            if (ship.IsHit(c))
                                tablero += HIT_SYMBOL;
                            else
                                tablero += ship.GetSymbol();
                        }
                        else
                            tablero += WATER_SYMBOL;
                    }
                    else
                    {
                        if (!IsSeen(c))
                            tablero += NOTSEEN_SYMBOL;
                        else
                        {
                            Ship ship = GetShip(c);
                            if (ship == null)
                                tablero += WATER_SYMBOL;
                            else
                            {
                                if (ship.IsShotDown())
                                    tablero += ship.GetSymbol();
                                else
                                    tablero += HIT_SYMBOL;
                            }
                        }
                    }
                }
                if (y != size - 1)
                    tablero += rn;
            }

            return tablero;
        }

        public override string ToString()
        {
            return $"Board {size}; crafts: {numCrafts}; destroyed: {destroyedCrafts}";
        }
    }
}
