namespace FestivalManager.Entities.Instruments
{
    public class Guitar : Instrument
    {
        public const int GuitarRepairAmout = 60;

       

        public override int RepairAmount => GuitarRepairAmout;
    }
}
