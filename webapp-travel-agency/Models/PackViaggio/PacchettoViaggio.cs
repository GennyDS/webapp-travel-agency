using System.ComponentModel.DataAnnotations;

namespace webapp_travel_agency.Models
{
    public class PacchettoViaggio
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "Il campo 'Nome' è obbligatorio")]
        [StringLength(20, ErrorMessage = "Il 'Nome' non può avere più di 20 caratteri")]
        public string nome { get; set; }
        public int prezzo{ get; set; }

        [Required(ErrorMessage = "Il campo 'Descrizione' è obbligatorio")]
        [StringLength(200, ErrorMessage = "la 'Descrizione' non può avere più di 200 caratteri")]
        public string descrizione { get; set; }

        [Required(ErrorMessage = "Il campo 'Immagine' è obbligatorio")]
        public string img { get; set; }

        public PacchettoViaggio()
        {

        }
        public PacchettoViaggio(string nome, int prezzo,string descrizione,string img)
        {
            
            this.nome = nome;
            this.prezzo = prezzo;
            this.descrizione = descrizione;
            this.img=img;

        }
    }
}
