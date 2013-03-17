using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChessByBird.Chess
{
      
    class Game
    {
        private String whiteName;
        private String blackName;
        private String savedfn;

        public string WhiteUser
        {
            get { return this.whiteName; }
            set { this.whiteName = value; }
        }
        public string BlackUser
        {
            get { return this.blackName; }
            set { this.blackName = value; }
        }
        public string Savedfn
        {
            get { return this.savedfn; }
            set { this.savedfn = value; }
        }

    }
}
