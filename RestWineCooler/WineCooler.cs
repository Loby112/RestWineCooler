using System;

namespace WineCoolerLib {
    public class WineCooler {
        private int _id;
        private int _capacityOfBottles;
        private int _temperature;
        private int _bottlesInStorage;

        public WineCooler(int id, int capacityOfBottles, int temperature, int bottlesInStorage){
            Id = id;
            CapacityOfBottles = capacityOfBottles;
            Temperature = temperature;
            BottlesInStorage = bottlesInStorage;
        }

        public int Id{
            get => _id;
            set => _id = value;
        }

        public int CapacityOfBottles{
            get => _capacityOfBottles;
            set => _capacityOfBottles = value;
        }

        public int Temperature{
            get => _temperature;
            set => _temperature = value;
        }

        public int BottlesInStorage{
            get => _bottlesInStorage;
            set{
                if (value < 0 || value > CapacityOfBottles) throw new ArgumentOutOfRangeException();
                _bottlesInStorage = value;
            }
        }

        public string Status{
            get{
                if (CoolerIsFull()){
                    return "Full";
                }
                else if (BottlesInStorage == 0){
                    return "Empty";
                }
                else{
                    return "Not Full";
                }
            }
        }

        public bool CoolerIsFull(){
            if (BottlesInStorage == CapacityOfBottles){
                return true;
            }
            else{
                return false;
            }
        }

        public int AddWine(){
            BottlesInStorage++;
            return BottlesInStorage;
        }
        public override string ToString(){
            return base.ToString();
        }
    }
}
