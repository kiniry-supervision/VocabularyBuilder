using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VocabularyGUI {
    abstract class Quiz {
        VocApp core;

        public Quiz(VocApp core) {
            this.core = core;
        }

    }
}
