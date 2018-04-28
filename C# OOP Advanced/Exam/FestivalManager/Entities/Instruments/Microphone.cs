namespace FestivalManager.Entities.Instruments
{
    public class Microphone : Instrument
    {
        public const int MicrophoneRepairAmout = 80;

        public override int RepairAmount => MicrophoneRepairAmout;
    }
}
