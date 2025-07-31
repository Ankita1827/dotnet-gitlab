export class Order{
    //private,protected and public
    //private readonly orderno:number;
    protected customername:string;
    public year:string;
    make:string;
    constructor(private orderno:number){
    }
    process(a:number,b:number){
            console.log(this.orderno)
    }
    Another(a:Human){
       // console.log(`${a.name} ${a.price}` )
    }
}

interface Item{
    name:string;
    price:number;
} 
export interface Human{
    laughing();
}

export class Sugan implements Human{
    laughing() {
        throw new Error("Method not implemented.");
    }

}