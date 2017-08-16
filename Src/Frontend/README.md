# SeatPlan

This project was generated with [Angular CLI](https://github.com/angular/angular-cli) version 1.0.3.

## Development server

Run `ng serve` for a dev server. Navigate to `http://localhost:4200/`. The app will automatically reload if you change any of the source files.

## Code scaffolding

Run `ng generate component component-name` to generate a new component. You can also use `ng generate directive|pipe|service|class|module`.

## Build

Run `ng build` to build the project. The build artifacts will be stored in the `dist/` directory. Use the `-prod` flag for a production build.

## Running unit tests

Run `ng test` to execute the unit tests via [Karma](https://karma-runner.github.io).

## Running end-to-end tests

Run `ng e2e` to execute the end-to-end tests via [Protractor](http://www.protractortest.org/).
Before running the tests make sure you are serving the app via `ng serve`.

## Further help

To get more help on the Angular CLI use `ng help` or go check out the [Angular CLI README](https://github.com/angular/angular-cli/blob/master/README.md).

## Running Protractor tests

### Setting up the environment

### Install dependencies
npm install

### Install Java environment
- JDK
- maven

### Run selenium standalone server
webdriver-manager start

### Run the tests
### Directly run protractor (no reports generated)
- default browser (Chrome)
`protractor conf.js`
- define browser
`protractor conf.js --params.browsers=<firefox, chrome, etc>`

### Run script and get the reports
- default browser (Chrome)
`sh run.sh`
- define browser
`sh run.sh <firefox, chrome, etc>`

Reports are in the `reports` folder

### Re-run failed tests
- Windows
`node flake protractor.conf.js`
- Mac
`./flake protractor.conf.js`

