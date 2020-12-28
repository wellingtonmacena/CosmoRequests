using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    class Player
    {
        public string _id { get; set; }
        public string name { get; set; }
        public int age { get; set; }
        public string nationality { get; set; }

        public Player(string name, int age, string nationality)
        {
            this.name = name;
            this.age = age;
            this.nationality = nationality;
        }


        public override string ToString()
        {
            return $"_id: {this._id},\nname: {this.name},\nage: {this.age},\nnationality: {this.nationality}\n ";
        }

    }


}
