using System;

namespace Gymbro.Api.Models
{

    public class ExerciseRecord
    {
        public string UserId { get; set; }  
        public Guid Id { get; set; }  
        public DateTimeOffset Date { get; set; }
        public string Exercise { get; set; }
        public string Equipment { get; set; }
        public Set[] Sets { get; set; } 
    }

    public class Set
    {
        public int Reps { get; set; }
        public double Weight { get; set; }
    }
} 