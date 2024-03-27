"use client";

import { DataGrid, GridColDef } from "@mui/x-data-grid";
import { useMany } from "@refinedev/core";
import {
  DateField,
  DeleteButton,
  EditButton,
  List,
  MarkdownField,
  ShowButton,
  useDataGrid,
} from "@refinedev/mui";
import React, { useRef, useState } from 'react';

import Card from '@mui/material/Card';
import CardActions from '@mui/material/CardActions';
import CardContent from '@mui/material/CardContent';
import Button from '@mui/material/Button';
import Typography from '@mui/material/Typography';

import { styled } from '@mui/material/styles';
import Box from '@mui/material/Box';
import Paper from '@mui/material/Paper';
import Grid from '@mui/material/Unstable_Grid2';
import Stack from '@mui/material/Stack';
import Flippy, { FrontSide, BackSide } from 'react-flippy';
import TriviaOption from "@app/TriviaOption/page";

export default function BlogPostList() {

  const flippyRef = useRef(null);

  const { dataGridProps } = useDataGrid({
    syncWithLocation: true,
  });

  const Item = styled(Paper)(({ theme }) => ({
    backgroundColor: theme.palette.mode === 'dark' ? '#1A2027' : '#fff',
    ...theme.typography.body2,
    padding: theme.spacing(1),
    textAlign: 'center',
    color: theme.palette.text.secondary,
  }));

  const [isHovered, setIsHovered] = useState(false);

  const { data: categoryData, isLoading: categoryIsLoading } = useMany({
    resource: "categories",
    ids:
      dataGridProps?.rows
        ?.map((item: any) => item?.category?.id)
        .filter(Boolean) ?? [],
    queryOptions: {
      enabled: !!dataGridProps?.rows,
    },
  });

  return (
    <Flippy
      flipOnHover={false} // default false
      flipOnClick={false} // default false
      flipDirection="horizontal" // horizontal or vertical
      ref={flippyRef} // to use toggle method like this.flippy.toggle()
      // if you pass isFlipped prop component will be controlled component.
      // and other props, which will go to div
      //style={{ width: '200px', height: '200px' }} /// these are optional style, it is not necessary
    >
      <FrontSide style={{backgroundColor: 'lightgray'}}>
        <Stack spacing={4}>
        <Paper>
            <CardContent>
              <Typography gutterBottom variant="h5" component="div">
                What is the capital of France?
              </Typography>
            </CardContent>
          </Paper>
          <Stack spacing={4} direction={"row"}>
            <TriviaOption OptionNumber="Option 1" OptionText="Paris" onClick={() => {flippyRef.current.toggle()}} />
            <TriviaOption OptionNumber="Option 1" OptionText="Paris" onClick={() => {flippyRef.current.toggle()}} />
            <TriviaOption OptionNumber="Option 1" OptionText="Paris" onClick={() => {flippyRef.current.toggle()}} />
            <TriviaOption OptionNumber="Option 1" OptionText="Paris" onClick={() => {flippyRef.current.toggle()}} />
          </Stack>
        </Stack>
      </FrontSide>
      <BackSide
        style={{ backgroundColor: '#175852'}}>
        ROCKS
      </BackSide>
    </Flippy>
  );
}
