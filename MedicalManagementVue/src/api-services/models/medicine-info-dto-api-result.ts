/* tslint:disable */
/* eslint-disable */
/**
 * MedicalManagement.WebAPI
 * No description provided (generated by Swagger Codegen https://github.com/swagger-api/swagger-codegen)
 *
 * OpenAPI spec version: 1.0
 * 
 *
 * NOTE: This class is auto generated by the swagger code generator program.
 * https://github.com/swagger-api/swagger-codegen.git
 * Do not edit the class manually.
 */
import { MedicineInfoDto } from './medicine-info-dto';
/**
 * 
 * @export
 * @interface MedicineInfoDtoApiResult
 */
export interface MedicineInfoDtoApiResult {
    /**
     * 
     * @type {string}
     * @memberof MedicineInfoDtoApiResult
     */
    message?: string | null;
    /**
     * 
     * @type {boolean}
     * @memberof MedicineInfoDtoApiResult
     */
    status?: boolean;
    /**
     * 
     * @type {MedicineInfoDto}
     * @memberof MedicineInfoDtoApiResult
     */
    result?: MedicineInfoDto;
}
