using System;

namespace PFC.SGP.UI.ViewModels.Home.Dashboard
{
    public class TrabalhoDashboardVM : AbstractEntity
    {
        public string Nome { get; set; }

        public String AnoApresentacao { get; set; }

        public String MesApresentacao { get; set; }

        public AlunoVM Aluno { get; set; } = new AlunoVM();

        public OrientadorVM Orientador { get; set; } = new OrientadorVM();

        public String Turma { get; set; }
    }
}
