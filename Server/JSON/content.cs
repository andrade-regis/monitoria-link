using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Server.JSON
{
    public class root
    {
        public Cabecalho cabecalho = new Cabecalho();
        public List<Link> links = new List<Link>();
    }

    public class Cabecalho
    {
        public int codigoApp { get; set; }  /*Exemplo 00 Servidor -- 01 Admin -- 02 Cliente*/
        public int codigoAção { get; set; } /*Exemplo 00 Novo Usuário -- 01 Manutenção Link  -- 02 Reenvio dos dados*/        
    }    

    public class Link
    {
        public DateTime hora { get; set; }
        public string destino { get; set; }
        public string compania { get; set; }
        public int voo { get; set; }
        public string codigoPassagem { get; set; }
        public int terminal { get; set; }
        public int portao { get; set; }
        public string observacao { get; set; }
    }
}
