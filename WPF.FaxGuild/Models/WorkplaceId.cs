using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WPF.FaxGuild.DAL.Models
{
    public class WorkplaceId
    {
        public WorkplaceId(int roomnumber, int placenumber)
        {
            Roomnumber = roomnumber;
            Placenumber = placenumber;
        }

        public int Roomnumber { get; }
        public int Placenumber { get; }

        public override bool Equals(object obj)
        {
            return obj is WorkplaceId placeId &&
                placeId.Roomnumber == Roomnumber &&
                placeId.Placenumber == Placenumber;
        }
        public override int GetHashCode()
        {
            return HashCode.Combine(Roomnumber, Placenumber);
        }
        public override string ToString()
        {
            return $"{Roomnumber} {Placenumber}";
        }
        public static bool operator ==(WorkplaceId left, WorkplaceId right)
        {
            if (left is null && right is null)
            {
                return true;
            }

            return !(left is null) && left.Equals(right);
        }
        public static bool operator !=(WorkplaceId left, WorkplaceId right)
        {
            return !(left == right);
        }
    }
}
