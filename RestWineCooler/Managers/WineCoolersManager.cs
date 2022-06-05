using System.Collections.Generic;
using Microsoft.AspNetCore.Authentication;
using WineCoolerLib;

namespace RestWineCooler.Managers {
    public class WineCoolersManager{
        private static int nextId = 1;

        private static List<WineCooler> coolersList = new List<WineCooler>(){
            new WineCooler(nextId++, 4, 18, 4),
            new WineCooler(nextId++, 4, 12, 0),
            new WineCooler(nextId++, 3, 12, 1),
            new WineCooler(nextId++, 48, 10, 44),
        };

        public IEnumerable<WineCooler> GetAllCoolers(){
            return coolersList;
        }

        public WineCooler GetCooler(int id){
            var result = coolersList.Find(C => C.Id == id);
            return result;
        }

        public WineCooler AddCooler(WineCooler cooler){
            cooler.Id = nextId++;
            coolersList.Add(cooler);
            return cooler;
        }

        public WineCooler DeleteCooler(int id){
            WineCooler result = coolersList.Find(C => C.Id == id);
            coolersList.Remove(result);
            return result;
        }

        public bool AddWine(int id){
            var result = coolersList.Find(C => C.Id == id);
            if (!result.CoolerIsFull()){
                result.AddWine();
                return true;
            }

            return false;

        }
    }
}
