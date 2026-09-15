package com.sgtux.hexagonal.application.core.usecase;

import com.sgtux.hexagonal.application.core.domain.Customer;
import com.sgtux.hexagonal.application.ports.in.InsertCustomerInputPort;
import com.sgtux.hexagonal.application.ports.out.FindAddressByZipCodeOutputPort;
import com.sgtux.hexagonal.application.ports.out.InsertCustomeroutputPort;
import com.sgtux.hexagonal.application.ports.out.SendCpfForValidationOutputPort;

public class InsertCustomerUseCase implements InsertCustomerInputPort {

    private final FindAddressByZipCodeOutputPort findAddressByZipCodeOutputPort;

    private final InsertCustomeroutputPort insertCustomeroutputPort;

    private final SendCpfForValidationOutputPort sendCpfForValidationOutputPort;

    public InsertCustomerUseCase(FindAddressByZipCodeOutputPort findAddressByZipCodeOutputPort, InsertCustomeroutputPort insertCustomeroutputPort, SendCpfForValidationOutputPort sendCpfForValidationOutputPort) {
        this.findAddressByZipCodeOutputPort = findAddressByZipCodeOutputPort;
        this.insertCustomeroutputPort = insertCustomeroutputPort;
        this.sendCpfForValidationOutputPort = sendCpfForValidationOutputPort;
    }

    public void insert(Customer customer, String zipCode) {
        var address = findAddressByZipCodeOutputPort.find(zipCode);
        customer.setAddress(address);
        insertCustomeroutputPort.insert(customer);
        sendCpfForValidationOutputPort.send(customer.getCpf());
    }
}