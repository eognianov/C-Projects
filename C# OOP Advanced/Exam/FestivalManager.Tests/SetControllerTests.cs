// Use this file for your unit tests.
// When you are ready to submit, REMOVE all using statements to your project (entities/controllers/etc)


using System.Collections.Generic;
using System.Linq;


namespace FestivalManager.Tests
{
	using NUnit.Framework;
	using System;

    [TestFixture]
	public class SetControllerTests
    {
        

		[Test]
	    public void SetPerform()
		{
		    Stage stage = new Stage();

		    ISetController setController = new SetController(stage);
            Performer performer = new Performer("Ivan", 24);
            performer.AddInstrument(new Drums());
            stage.AddPerformer(performer);
            Song song = new Song("pesen", new TimeSpan(0,3,0));
            Set set = new Medium("Set1");
            set.AddPerformer(performer);
            set.AddSong(song);
		    stage.AddSet(set);

		    string result = setController.PerformSets();

		    string expectedOutput = "1. Set1:\r\n-- 1. pesen (03:00)\r\n-- Set Successful";

            Assert.That(result, Is.EqualTo(expectedOutput) );

		}

        [Test]
        public void InstrumentsToRepair()
        {
            Stage stage = new Stage();

            ISetController setController = new SetController(stage);
            Performer performer = new Performer("Ivan", 24);
            performer.AddInstrument(new Drums());
            stage.AddPerformer(performer);
            Song song = new Song("pesen", new TimeSpan(0, 3, 0));
            Set set = new Medium("Set1");
            set.AddPerformer(performer);
            set.AddSong(song);
            stage.AddSet(set);

            int expectedInstrumets = 1;

            setController.PerformSets();

            var instrumentsToRepair = stage.Performers
                .SelectMany(p => p.Instruments)
                .Where(i => i.Wear <= 100)
                .ToArray();

            Assert.That(instrumentsToRepair.Length, Is.EqualTo(expectedInstrumets));
        }

	}
}