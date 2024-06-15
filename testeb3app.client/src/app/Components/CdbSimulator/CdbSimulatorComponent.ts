export class IncomeSimulationResult {
  grossValue: number = 0;
  netValue: number = 0;
}

import { HttpClient } from '@angular/common/http';
import { Component } from '@angular/core';


@Component({
  selector: 'Cdb-Simulator',
  templateUrl: './CdbSimulatorComponent.html',
  styleUrl: './CdbSimulatorComponent.css'
})
export class CdbSimulatorComponent {

  public initialInvestiment: number = 0;
  public monthQuantity: number = 0;
  public incomeSimulationResult: IncomeSimulationResult = new IncomeSimulationResult();
  public grossValue: number = 0;
  public netValue: number = 0;

  constructor(private http: HttpClient) { }

  Simulate() {

    if (this.initialInvestiment <= 0) {
      alert('Investiment value must be greater than zero.')
      return;
    }

    if (this.monthQuantity <= 1) {
      alert('Quantity months must be greater than one.')
      return;
    }
    
    this.http.post<IncomeSimulationResult>('https://localhost:7295/api/Simulation',
      {
        valueApplication: this.initialInvestiment,
        quantityMounth: this.monthQuantity
      })
      .subscribe(
        (result) => {
          this.incomeSimulationResult = result;
        },
        (error) => {
          console.log(error);
        }
      );
  }
}
