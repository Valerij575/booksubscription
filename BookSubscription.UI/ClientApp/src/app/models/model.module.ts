import { NgModule } from "@angular/core";
import { HttpClientModule } from "@angular/common/http";
import { Repository } from './repository.model';


@NgModule({
    imports: [HttpClientModule],
    providers: [Repository]
})

export class ModelModule {}