﻿namespace HackathonBackEnd.Models.Dominio
{
    public class Endereco
    {
        public string Rua { get; set; }
        public int Numero { get; set; }
        public string CEP { get; set; }
        public string Cidade { get; set; }
        public string Estado { get; set; }
        public string Pais { get; set; }
    }
}