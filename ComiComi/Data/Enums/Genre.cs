using System.ComponentModel.DataAnnotations;

namespace ComiComi.Data.Enums
{
    public enum Genre
    {
        Action = 1,
        Adventure,
        Comedy,
        Drama,
        Fantasy,
        [Display(Name = "Slice of Life")]
        SliceOfLife,
        Romance,
        [Display(Name = "Sci-Fi")]
        SciFi,
        Sports,
        Historical,
        Supernatural,
        Horror,
        Mystery,
        Dark,
    }
}
