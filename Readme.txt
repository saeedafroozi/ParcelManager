/* 
 * You work at a parcel delivery company and you are asked to design a system to automate the internal handling of parcels coming in.
 * 
 * The parcels are coming in at the distribution center and need to be handled by different departments based on their weight and value. 
 * 
 * Currently management is making plans that could lead to the adding or removal of departments in the future.
 *
 * The current business rules are as follows:
 * 
 * - Parcels with a weight up to 1 kg are handled by the "Mail" departement.
 * - Parcels with a weight up to 10 kg are handled by the "Regular" department.
 * - Parcels with a weight over 10 kg are handled by the "Heavy" department.
 * - Parcels with a value of over � 1000,- need to be signed off by the "Insurance" department, before being processed by Mail, Regular or Heavy department.
 *
 * Excercise:
 * 
 * - Parse the XML file (C:\ParcelDelivery\Data\Container_68465468.xml)
 * - Write some working code that reflect the given business rules.
 * - Unit test coverage
 * - Presentation (maybe some UI / Console app)
 *
 * Afterwards:
 * - Demonstrate the behavior of the code.
 * - Show us how adding or removing a department would be done.
 */