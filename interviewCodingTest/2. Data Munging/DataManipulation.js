class AcceptableExpenceSheet{
    constructor(categories, expenses) {
        this.AcceptableCategories = this.GetAcceptableCategories(categories);
        this.AcceptableExpenses = this.GetAcceptableExpenses (expenses)
      }

    GetAcceptableExpenses(expenses){
        const ExpensesList = expenses.split("\n")
        let AcceptableExpenseTotals = {};
        let venderDate = []
        
        ExpensesList.forEach(expense => {
            const [vender,date,,price,category] = expense.split(',')

            if ( this.AcceptableCategories.includes(category)){
                venderDate = [date, ": ", vender, " - $"].join('')

                if ( venderDate in AcceptableExpenseTotals){
                    AcceptableExpenseTotals[venderDate] += parseFloat(price);
                }
                else{
                    AcceptableExpenseTotals[venderDate] = parseFloat(price);
                }
            }
        })
        return AcceptableExpenseTotals
    }

    GetAcceptableCategories(categories){
        const categoryList = categories.split("\n")
        const AcceptableCategory = []

        for (let i = 0; i < categoryList.length; i++){
            const [Category,,IsExpensible] = categoryList[i].split(',');

            if (IsExpensible === "Y" ){
                    AcceptableCategory.push(Category)
            }
        }
        return AcceptableCategory
    }

    Print(){
        const keys = Object.keys(this.AcceptableExpenses);
        
        keys.forEach((key, index) => {
            console.log(`${key} ${this.AcceptableExpenses[key]}`);
        });
    }
}
// Input Values
const categories = "CFE,Coffee,Y\nFD,Food,Y\nPRS,Personal,N";
const expenses = "Starbucks,3/10/2018,Iced Americano,4.28,CFE\nStarbucks,3/10/2018,Nitro Cold Brew,3.17,CFE\nStarbucks,3/10/2018,Souvineer Mug,8.19,PRS\nStarbucks,3/11/2018,Nitro Cold Brew,3.17,CFE\nHigh Point Market,3/11/2018,Iced Americano,2.75,CFE\nHigh Point Market,3/11/2018,Pastry,2.00,FD\nHigh Point Market,3/11/2018,Gift Card,10.00,PRS";
// Acceptable: 
//------------------------------------------------
//        Starbucks,        3/10/2018,Iced Americano, 4.28,CFE
//        Starbucks,        3/10/2018,Nitro Cold Brew,3.17,CFE
// TOTAL: Starbucks,        3/10/2018,***,            7.45,CFE *** Total
//        Starbucks,        3/11/2018,Nitro Cold Brew,3.17,CFE
// TOTAL: Starbucks,        3/11/2018,Nitro Cold Brew,3.17,CFE *** Total
//        High Point Market,3/11/2018,Iced Americano, 2.75,CFE
//        High Point Market,3/11/2018,Pastry,         2.00,FD
// TOTAL: High Point Market,3/11/2018,***,            4.75,FD  *** Total
// Not Acceptable
//------------------------------------------------
// Starbucks,        3/10/2018,Souvineer Mug, 8.19,PRS
// High Point Market,3/11/2018,Gift Card,    10.00,PRS

ExpenseCalculation = new AcceptableExpenceSheet(categories, expenses);
ExpenseCalculation.Print();

console.log("Processing complete")

