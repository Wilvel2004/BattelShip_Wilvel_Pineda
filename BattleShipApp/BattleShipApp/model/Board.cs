using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BattleShipApp.model
{
    public class Board
    {
        public static readonly char HIT_SYMBOL = '·';
        public static readonly char WATER_SYMBOL = ' ';
        public static readonly char NOTSEEN_SYMBOL = '?';
        private static readonly int MAX_BOARD_SIZE = 20;
        private static readonly int MIN_BOARD_SIZE = 5;

        private Dictionary<Coordinate, Ship> board;
        private HashSet<Coordinate> seen;
        private int size;
        private int numCrafts;
        private int destroyedCrafts;

        public Board(int size){
            numCrafts = 0;
            destroyedCrafts = 0;
            board = new Dictionary<Coordinate, Ship>();
            seen = new HashSet<Coordinate>();

            if(size < MIN_BOARD_SIZE || size > MAX_BOARD_SIZE) {

                Form1.console.WriteLine("Size is not in Board size");
                size = MIN_BOARD_SIZE;
            }
            else
            {
                this.size = size;
            }
        
        }
        public bool AreAllCraftsDestroyed()
        {
            if(destroyedCrafts == numCrafts)
            {
                return true;
            }
            return false;
        }
        public bool CheckCoordinate(Coordinate coord)
        {
            if(coord.Get(0) >= 0 && coord.Get(0) < size && coord.Get(1) >= 0 && coord.Get(1) < size)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public Ship GetShip(Coordinate c)
        {
            if (board.ContainsKey(c))
            {
                return board[c];
            }
            else
            {
                return null;
            }
        }

        public bool isSeen(Coordinate c)
        {
            return seen != null && seen.Contains(c);
        }

        public HashSet<Coordinate> GetNeighborHood(Ship ship, Coordinate positions)
        {
            HashSet<Coordinate> result = new HashSet<Coordinate>();
            foreach (Coordinate coor in ship.GetAbsolutePosition(positions)){
                foreach(Coordinate coorAux in coor.AdjacentCoordinates())
                    if (CheckCoordinate(coorAux))
                    {
                        result.Add(coorAux);
                    }
            }
            foreach(Coordinate coor in ship.GetAbsolutePosition(positions))
            {
                result.Remove(coor);
            }
            return result;
        }

        public HashSet<Coordinate> GetNeighborHood(Ship ship)
        {
            return GetNeighborHood(ship, ship.GetPosicion());
        }

        public CellStatus Hit(Coordinate c)
        {
            //Check if c is outside of board
            if (!CheckCoordinate(c)){
                Form1.console.WriteLine($"Coordinate {c} is out of bounds");
                return CellStatus.Water;
            }
            else
            {
                seen.Add(c);

                Ship ship = GetShip(c);
                if( ship == null)
                {
                    return CellStatus.Water;
                }
                else
                {
                    if (ship.Hit(c)) //it is hitted
                    {
                        if (ship.isShotDown())
                        {
                            HashSet<Coordinate> neighbors = GetNeighborHood(ship);
                            foreach (Coordinate coor in neighbors)
                            {
                                seen.Add(coor);
                            }

                            destroyedCrafts++;
                            return CellStatus.Destroyed;
                        }
                        else
                        {
                            return CellStatus.Hit;
                        }
                    }
                    else
                    {
                        //it's no hitted
                        return CellStatus.Water;
                    }
                }
            }
        }

        public bool AddShip(Ship ship,Coordinate position)
        {
            //Check the ship is not out of bounds
            HashSet<Coordinate> coordinates = ship.GetAbsolutePosition(position);
            foreach (Coordinate c in coordinates)
            {
                if (!CheckCoordinate(c))
                {
                    Form1.console.WriteLine($"Coordinate {c} is out of bounds");
                    return false;
                }
            }
            //Check if all Coordinates are not occupied
            foreach (Coordinate c in coordinates)
            {
                if (board.ContainsKey(c))
                {
                    Form1.console.WriteLine($"Coordinate {c} is occupeted by other ship");
                    return false;
                }
            }
            //Check that there are not neighbors
            HashSet<Coordinate> neighbors = GetNeighborHood(ship,position);
            foreach (Coordinate c in neighbors)
            {
                if(GetShip(c) != null)
                {
                    Form1.console.WriteLine($"Coordinate {c} is in a neghborhood");
                    return false;
                }
            }
            //Add ship
            ship.SetPosition(position);
            foreach(Coordinate c in coordinates)
            {
                board.Add(c, ship);
            }
            numCrafts++;
            return true;
        }
        public string Show(bool unveil)
        {
            string rn = "\r\n";
            string tablero = "";

            for (int y = 0; y < size; y++)
            {
                for(int  x = 0; x < size; x++)
                {
                    Coordinate c = new Coordinate(x, y);
                    Ship ship = GetShip(c);
                    if (unveil)
                    {
                        if(ship != null)
                        {
                            if (ship.IsHit(c))
                            {
                                tablero += HIT_SYMBOL;
                            }
                            else
                            {
                                tablero += ship.getSymbol();
                            }
                        }
                        else
                        {
                            tablero += WATER_SYMBOL;
                        }
                    }
                    else
                    {
                        if (!isSeen(c))
                        {
                            tablero += NOTSEEN_SYMBOL;
                        }
                        else
                        {
                            if(ship == null)
                            {
                                tablero += WATER_SYMBOL;
                            }
                            else
                            {
                                if (ship.isShotDown())
                                {
                                    tablero += ship.getSymbol();
                                }
                                else
                                {
                                    tablero += HIT_SYMBOL;
                                }
                            }
                        }
                    }
                }
                if(y != size - 1)
                {
                    tablero += rn;
                }
            }

            return tablero;
        }
        public override string ToString()
        {
            return $"Board {size}; Crafts {numCrafts}; Destroyed {destroyedCrafts}";
        }
    }
}
