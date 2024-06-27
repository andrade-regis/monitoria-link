using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Server.JSON
{
    public class root
    {
        public content conteudo = new content();
        public List<Link> links = new List<Link>();
    }

    public class content
    {
        public int codigoApp { get; set; }  /*Exemplo 00 Servidor -- 01 Admin -- 02 Cliente*/
        public int codigoAção { get; set; } /*Exemplo 00 Novo Usuário -- 01 Manutenção Link */        
    }    

    public class Link
    {
        public int id { get; set; }
        public string sigla { get; set; }
        public string nome { get; set; }
        public string velocidade { get; set; }
        public bool linkSegueMonitorado { get; set; }
        public bool linkUp { get; set; }
    }
}
