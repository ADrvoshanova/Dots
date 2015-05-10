using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace MainForm
{
    [Serializable]
    public class Player : ISerializable, IComparable<Player>
    {
        public string Username { get; set; }
        public int Score { get; set; }

        public Player(string u, int s)
        {
            Username = u;
            Score = s;
        }

        public override string ToString()
        {
            return String.Format("{0} {1} \n", Username, Score);
        }
        private Player(SerializationInfo info, StreamingContext context)
        {
            Username = info.GetString("Username");
            Score = info.GetInt32("Score");
        }

        public void GetObjectData(SerializationInfo inf, StreamingContext con)
        {
            inf.AddValue("Username", Username);
            inf.AddValue("Score", Score);

        }

        public int CompareTo(Player o)
        {
            return this.Score.CompareTo(o.Score);
        }

        public bool Equals(Player o)
        {
            return this.Username.Equals(o.Username) && this.Score.Equals(o.Score);
        }
    }
}
