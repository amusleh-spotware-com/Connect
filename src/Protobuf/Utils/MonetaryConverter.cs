namespace Connect.Protobuf.Utils
{
    public static class MonetaryConverter
    {
        public static long FromMonetary(long monetaryValue) => monetaryValue / 100;

        public static long ToMonetary(long value) => value * 100;
    }
}