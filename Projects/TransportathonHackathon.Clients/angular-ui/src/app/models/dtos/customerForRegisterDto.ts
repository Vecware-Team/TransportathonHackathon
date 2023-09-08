import { Customer } from "../entities/customer";
import { UserForRegisterDto } from "./userForRegisterDto";

export interface CustomerForRegisterDto{
    user:UserForRegisterDto;
    customer:Customer;
}