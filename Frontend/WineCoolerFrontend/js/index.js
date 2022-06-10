const Url = "https://restwinecooler20220604094231.azurewebsites.net/api/winecoolers"

Vue.createApp({
    data(){
        return{
            wineCoolers: [],
            newWineCooler: {"id": 0,"capacityOfBottles":null,"temperature":null,"bottlesInStorage":null},
            getWineCooler: null,
            getById: 0,
            coolerId: 0,
            addMessage: "",

        }
    },
    created(){
        this.getAllCoolers()
    },
    methods: {
        async helperGetAndShow(url){
            try{
                const response = await axios.get(url)
                this.wineCoolers = await response.data
            } catch (ex){
                alert(ex.message)
            }
        },

        getAllCoolers(){
            this.helperGetAndShow(Url)
            
        },

        async getSingleCooler(id){
            const singleUrl = Url + "/" + id
            try{
                const response = await axios.get(singleUrl)
                this.getWineCooler = await response.data
            } catch (ex){
                alert(ex.message)
            }
        },

        async addNewCooler(){
            try{
                response = await axios.post(Url, this.newWineCooler)
                this.getAllCoolers()
            } catch (ex){
                alert(ex.message)
            }
        }, 

        async addWine(id){
            let url = Url + "/" + id + "/AddWine"
            try{
                response = await axios.get(url)
                this.addMessage = "response " + response.status + " " + response.statusText
            } catch (ex){
                alert(ex.message)

            }
            this.getAllCoolers()
        }
    }




}).mount('#app')