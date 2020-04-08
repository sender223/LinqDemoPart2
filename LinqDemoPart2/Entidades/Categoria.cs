namespace LinqDemoPart2.Entidades {
    class Categoria {


        public int Id { get; set; }
        public string Nome { get; set; }
        //nivel de categoria - top - medio - etc
        public int Tier { get; set; }
    }
}
