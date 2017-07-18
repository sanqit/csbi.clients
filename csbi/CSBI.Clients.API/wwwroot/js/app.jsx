var SearchClients = React.createClass({

    getInitialState: function () {
        return {
            filter: {
                firstName: "",
                middleName: "",
                lastName: "",
                address: ""
            },
            clients: null,
            totalClientsCount: 0
        };
    },

    handleChange: function (e) {
        var filter = this.state.filter;
        filter[e.target.id] = e.target.value;
        this.setState(filter);
    },

    handleKeyPress: function (e) {
        if (e.key === "Enter") {
            this.handleSearch();
        }
    },

    handleSearch: function () {
        $.ajax({
            url: this.props.url,
            dataType: "json",
            data: this.state.filter,
            cache: false,
            success: function (data, status, response) {
                this.setState({ clients: data, totalClientsCount: response.getResponseHeader("X-Total-Count") });
            }.bind(this),
            error: function (xhr, status, err) {
                if (xhr.status === 404) {
                    this.setState({ clients: [] });
                } else {
                    console.error(this.props.url, status, err.toString());
                }
            }.bind(this)
        });
    },

    getClientsView: function () {
        return <div>
            <div>Всего клиентов: {this.state.totalClientsCount}</div>
            <ul>
                {this.state.clients.map(function (l) {
                    return <li>
                        <div style={{ display: "grid" }}>
                            <span>Фамилия: {l.lastName}</span>
                            <span>Имя: {l.firstName}</span>
                            <span>Отчество: {l.middleName}</span>
                        </div>
                        <hr />
                        <div style={{ display: "grid" }}>{(l.addresses != null ? l.addresses : []).map(function (a) {
                            return <span>{a}</span>;
                        })}</div>
                    </li>;
                })}
            </ul>;
               </div>;
    },

    render: function () {
        var clientsVeiw;
        if (this.state.clients == null) {
            clientsVeiw = null;
        }
        else if (this.state.clients.length > 0) {
            clientsVeiw = this.getClientsView();
        } else {
            clientsVeiw = <div>Клиенты не найдены</div>;
        }
        return <div>
            <div><a href="swagger/ui" style={{ left: 0, top: 0, position: "absolute" }}>Go to swagger</a></div>
            <input type="text" id="firstName" value={this.state.filter.firstName} onChange={this.handleChange} onKeyPress={this.handleKeyPress} placeholder="Введите имя" />
            <input type="text" id="middleName" value={this.state.filter.middleName} onChange={this.handleChange} onKeyPress={this.handleKeyPress} placeholder="Введите отчество" />
            <input type="text" id="lastName" value={this.state.filter.lastName} onChange={this.handleChange} onKeyPress={this.handleKeyPress} placeholder="Введите фамилию" />
            <input type="text" id="address" value={this.state.filter.address} onChange={this.handleChange} onKeyPress={this.handleKeyPress} placeholder="Введите адрес" />
            <button type="button" id="searchButton" onClick={this.handleSearch}>Поиск</button>
            {clientsVeiw}
        </div>;

    }
});

ReactDOM.render(
    <SearchClients url="/clients" />,
    document.getElementById("app")
);