namespace Connect.Protobuf.Utils
{
    public static class VolumeConverter
    {
        public static double UnitsMonetaryToLots(long volumeInUnitsMonetary, long lotsInUnitsMonetary)
        {
            var lotsInUnits = MonetaryConverter.FromMonetary(lotsInUnitsMonetary);

            return MonetaryConverter.FromMonetary(volumeInUnitsMonetary) / lotsInUnits;
        }

        public static long LotsToUnitsMonetary(double volumeInLots, long lotsInUnitsMonetary)
        {
            var lotsInUnits = MonetaryConverter.FromMonetary(lotsInUnitsMonetary);

            var volumeInUnits = volumeInLots * lotsInUnits;

            return MonetaryConverter.ToMonetary(volumeInUnits);
        }
    }
}