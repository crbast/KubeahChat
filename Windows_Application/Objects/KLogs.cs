using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KChat.Objects
{
    // To complete
    class KLogs
    {
        public void Write(KLogsType type)
        {

        }

        /// <summary>
        /// Write event.
        /// </summary>
        /// <param name="type">Can use Klogs.KLogsType.Type<Type>()</param>
        public void Write(int type)
        {

        }
    }

    class KLogsType {
        private int type = 2;
        KLogsType(int type)
        {
            this.type = type;
        }
        public new int GetType() => this.type;

        public int Error() => 0;
        public int Warning() => 1;
        public int Info() => 2;

        public static int TypeError() => 0;
        public static int TypeWarning() => 1;
        public static int TypeInfo() => 2;
    }
}
