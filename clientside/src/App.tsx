import React, { useEffect, useState } from 'react';
import { Grid, FormControl, Typography, Input, InputLabel, InputAdornment } from '@material-ui/core';
import axios from 'axios'

const regex = new RegExp("^[0-9]+.{0,1}[0-9]{0,2}$")

const App = () => {

  const [userInput, setUserInput] = useState<string>();
  const [response, setResponse] = useState<string>();

  function isValid() {
    return userInput ? regex.test(userInput) : false
  }

  useEffect(() => {
    if (isValid()) {
      axios.get("https://localhost:5001/Bank/ConvertToString", {
        params: {
          value: userInput
        }
      }).then(
        ({ data }) => {
          if (data) {
            setResponse(data);
          } else {
            setResponse(undefined);
          }
        }
      )
    } else {
      setResponse(undefined);
    }
  }, [userInput])

  return (
    <Grid
      container
      spacing={0}
      direction="row"
      alignItems="center"
      justify="center"
      style={{ minHeight: '100vh' }}
    >

      <Grid container direction="column" xs={8}>
        <Grid item xs={12}>
          <Typography style={{marginBottom: 40}}>
            Please enter a value in the box below to convert it into words.
          </Typography>
        </Grid>

        <Grid item xs={12}>
          <FormControl fullWidth>
            <InputLabel htmlFor="standard-adornment-amount">Amount</InputLabel>
            <Input
              error={!isValid()}
              id="standard-adornment-amount"
              value={userInput}
              onChange={(e) => {
                setUserInput(e.target.value)
              }}
              startAdornment={<InputAdornment position="start">$</InputAdornment>}
            />
          </FormControl>
        </Grid>

        <Grid item xs={12}>
          <Typography style={{minHeight: 40, marginTop: 40}}>
            {response}
          </Typography>
        </Grid>

      </Grid>
    </Grid>
  );
}

export default App;
