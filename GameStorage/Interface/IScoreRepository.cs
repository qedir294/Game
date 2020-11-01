using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameStorage
{
    public interface IScoreRepository
    {
        void Insert(ScoreModel score);

        List<ScoreModel> GetAll();
    
    
    }



}
