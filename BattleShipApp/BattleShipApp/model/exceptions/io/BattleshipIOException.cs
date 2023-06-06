using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BattleShipApp.model.exceptions.io
{
    public class BattleshipIOException : BattleshipException
    {
        private string message;

        public BattleshipIOException(string message)
        {
            this.message = message;
        }

        public new string GetMessage()
        {
            return $"BattelshipIOExecption: Execption IO ocurred: {message}";
        }
    }
}
