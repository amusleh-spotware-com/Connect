using System;

namespace Connect.Protobuf.Utils
{
    public static class MonetaryConverter
    {
        public static double FromMonetary(long monetaryValue) => monetaryValue / 100.0;

        public static long ToMonetary(double value) => Convert.ToInt64(value * 100);
    }
}