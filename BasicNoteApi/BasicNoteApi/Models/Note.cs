using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BasicNoteApi.Models
{
    public class Note
    {
        [Key]
        public int NoteId { get; set; }

        [Required]
        public string Content { get; set; }// boş bırakılamaz


        public DateTime CreatedAt { get; set; } = DateTime.Now;

        // Foreign key
        [ForeignKey("User")]// uniqe olsun diye forigen key koydum 
        public int UserId { get; set; }

        public User? User { get; set; }
    }
}
