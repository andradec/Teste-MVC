using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;

namespace TesteMVC.Models
{
    public class Amigo
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "O campo Nome é obrigatório.")]
        public string Nome { get; set; }

        [Required(ErrorMessage = "O campo Celular é obrigatório.")]
        public string Celular { get; set; }

        [Required(ErrorMessage = "O campo Sexo é obrigatório.")]
        public int SexoId { get; set; }

        [Required(ErrorMessage = "O campo Rua é obrigatório.")]
        public string Rua { get; set; }

        [Required(ErrorMessage = "O campo Numero é obrigatório.")]
        public int Numero { get; set; }

        [Required(ErrorMessage = "O campo Bairro é obrigatório.")]
        public string Bairro { get; set; }

        [Required(ErrorMessage = "O campo Cep é obrigatório.")]
        public string Cep { get; set; }

        [Required(ErrorMessage = "O campo Cidade é obrigatório.")]
        public string Cidade { get; set; }

        [Required(ErrorMessage = "O campo CPF é obrigatório.")]
        public string Cpf { get; set; }

        public virtual ICollection<Emprestimo> Emprestimo { get; set; }

        public virtual Sexo Sexo { get; set; }

    }



}
