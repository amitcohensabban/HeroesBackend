namespace Heroes.Models
{
    public class Hero
    {
        public string? Name { get; set; }
        public string? Abillity { get; set; }
        public int? Id { get; set; }
        public string? StartToTrain { get; set; }
        public string? SuitColor { get; set; }
        public double? StartingPower { get; set; }
        public double? CurrentPower { get; set; }
        public string? guideId { get; set; }
        public Guide? guide { get; set; }
        public int? amountTrainingPerDay { get; set; }
        public string? lastTrainingDate { get; set; } 

    }
}
