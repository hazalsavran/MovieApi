using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace MovieApi.Application.Features.CQRSDesignPattern.Commands.MovieCommands
{
    public class CreateMovieCommand
    {
        public int MovieId { get; set; }
       
        [JsonPropertyName("title")]
        public string Title { get; set; }
       
        [JsonPropertyName("description")]
        public string Description { get; set; }
       
        [JsonPropertyName("coverImageUrl")]
        public string CoverImageUrl { get; set; }
       
        [JsonPropertyName("rating")]
        public decimal Rating { get; set; }
        
        [JsonPropertyName("duration")]
        public int Duration { get; set; }
       
        [JsonPropertyName("releaseDate")]
        public DateTime ReleaseDate { get; set; }
       
        [JsonPropertyName("createdYear")]
        public string CreatedYear { get; set; }
       
        [JsonPropertyName("status")]
        public bool Status { get; set; }
    }
}
